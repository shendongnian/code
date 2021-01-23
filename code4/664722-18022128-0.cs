    //           *-----------------------------------------------------------------*
    //           *                                                                 *
    //           *    CRIADO POR...: Julio C. Borges.                              *
    //           *    DATA.........: 19/07/2013.                                   *
    //           *    MOTIVO.......:                                               *
    //           *                                                                 *
    //           *-----------------------------------------------------------------*
    
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.Migrations.Sql;
    using System.Data.Metadata.Edm;
    using System.Data.SQLite;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    namespace ICM_Conexao.SqLite.Classes
    {
        /// <sumary>
        /// MigrationSqLiteGenerator 
        /// </sumary>
        public class MigrationSqLiteGenerator : MigrationSqlGenerator
        {
            #region Constantes
    
            private const string pstrDefaultDateTime = "yyyy-MM-dd hh:mm:ss";
            private const int pintDefaultStringMaxLength = 255;
            private const int pintDefaultPrecisaoNumerica = 10;
            private const byte pbytDefaultPrecisaoTempo = 7;
            private const byte pintDefaultEscala = 0;
            //private const string pstrNomeTabelaMigration = "__MigrationHistory"; 
    
            #endregion
            
            #region Instancias
    
            private DbProviderManifest pprovProviderManifest;
            private List<MigrationStatement> plstComandos;
            private bool pblnGerouPrimaryKey;
    
            #endregion
            
            #region Método de Geração sobrescrito de MigratioSqlGenerator
    
            public override IEnumerable<MigrationStatement> Generate(
                IEnumerable<MigrationOperation> lstOperacoesMigrations, string strManifestoProvider)
            {
                plstComandos = new List<MigrationStatement>();
    
                InicializaServicosProvider(strManifestoProvider);
                GeraComandos(lstOperacoesMigrations);
    
                return plstComandos;
            }
    
            #endregion
    
            #region Métodos de geração dos comandos
    
            protected virtual void Generate(CreateTableOperation opeCriacaoTabela)
            {
                // Preferencialmente não iremos gerar a tabela de dados do Migration
                if (opeCriacaoTabela.Name.Contains("MigrationHistory"))
                    return;
    
                using (var ltextWriter = TextWriter())
                {
                    GeraComandoCriacaoTabela(opeCriacaoTabela, ltextWriter);
    
                    ComandoSQL(ltextWriter);
                }
            }
    
            protected virtual void Generate(AddForeignKeyOperation opeChaveEstrangeira)
            {
                // Inicialmente não havera a criação de chave estrangeira
            }
    
             protected virtual void Generate(DropForeignKeyOperation dropForeignKeyOperation)
            {
                // Inicalmente não haverá a criação de chave estrangeira
            }
    
            protected virtual void Generate(CreateIndexOperation opeCriacaoIndex)
            {
                using (var ltextWriter = TextWriter())
                {
                    ltextWriter.Write("CREATE ");
    
                    if (opeCriacaoIndex.IsUnique)
                        ltextWriter.Write(" UNIQUE ");
    
                    ltextWriter.Write("INDEX ");
                    ltextWriter.Write(opeCriacaoIndex.Name);
                    ltextWriter.Write(" ON ");
                    ltextWriter.Write(RemoveDBO(opeCriacaoIndex.Table));
                    ltextWriter.Write("(");
    
                    for (int lintCount = 0; lintCount < opeCriacaoIndex.Columns.Count; lintCount++)
                    {
                        var lstrDadosColuna = opeCriacaoIndex.Columns[lintCount];
    
                        ltextWriter.Write(lstrDadosColuna);
    
                        if (lintCount < opeCriacaoIndex.Columns.Count - 1)
                            ltextWriter.WriteLine(",");
                    }
    
                    ltextWriter.Write(")");
    
                    ComandoSQL(ltextWriter);
                }
            }
    
             protected virtual void Generate(DropIndexOperation opeDropIndex)
            {
                using (var ltextWriter = TextWriter())
                {
                    ltextWriter.Write("DROP INDEX ");
                    ltextWriter.Write(opeDropIndex.Name);
    
                    ComandoSQL(ltextWriter);
                }
            }
    
             protected virtual void Generate(AddPrimaryKeyOperation opeAdicionaPrimaryKey)
            {
                using (var ltextWriter = TextWriter())
                {
                    ltextWriter.Write("ALTER TABLE ");
                    ltextWriter.Write(RemoveDBO(opeAdicionaPrimaryKey.Table));
                    ltextWriter.Write(" ADD CONSTRAINT ");
                    ltextWriter.Write(opeAdicionaPrimaryKey.Name);
                    ltextWriter.Write(" PRIMARY KEY ");
                    ltextWriter.Write("(");
    
                    for (int li = 0; li < opeAdicionaPrimaryKey.Columns.Count; li++)
                    {
                        var lstrDadosColuna = opeAdicionaPrimaryKey.Columns[li];
    
                        ltextWriter.Write(lstrDadosColuna);
    
                        if (li < opeAdicionaPrimaryKey.Columns.Count - 1)
                            ltextWriter.WriteLine(",");
                    }
    
                    ltextWriter.Write(")");
    
                    ComandoSQL(ltextWriter);
                }
            }
    
            protected virtual void Generate(DropPrimaryKeyOperation opeDropPrimaryKey)
            {
                using (var ltextWriter = TextWriter())
                {
                    ltextWriter.Write("ALTER TABLE ");
                    ltextWriter.Write(RemoveDBO(opeDropPrimaryKey.Table));
                    ltextWriter.Write(" DROP CONSTRAINT ");
                    ltextWriter.Write(opeDropPrimaryKey.Name);
    
                    ComandoSQL(ltextWriter);
                }
            }
    
            protected virtual void Generate(AddColumnOperation opeAdicionaColuna)
            {
                using (var ltextWriter = TextWriter())
                {
                    ltextWriter.Write("ALTER TABLE ");
                    ltextWriter.Write(RemoveDBO(opeAdicionaColuna.Table));
                    ltextWriter.Write(" ADD ");
    
                    var lcmColuna = opeAdicionaColuna.Column;
    
                    Generate(lcmColuna, ltextWriter, null);
    
                    if ((lcmColuna.IsNullable != null)
                        && !lcmColuna.IsNullable.Value
                        && (lcmColuna.DefaultValue == null)
                        && (string.IsNullOrWhiteSpace(lcmColuna.DefaultValueSql))
                        && !lcmColuna.IsIdentity
                        && !lcmColuna.IsTimestamp
                        && !lcmColuna.StoreType.Equals("rowversion", StringComparison.InvariantCultureIgnoreCase)
                        && !lcmColuna.StoreType.Equals("timestamp", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ltextWriter.Write(" DEFAULT ");
    
                        if (lcmColuna.Type == PrimitiveTypeKind.DateTime)
                        {
                            ltextWriter.Write(Generate(DateTime.Parse("1900-01-01 00:00:00", CultureInfo.InvariantCulture)));
                        }
                        else
                        {
                            ltextWriter.Write(Generate((dynamic)lcmColuna.ClrDefaultValue));
                        }
                    }
    
                    ComandoSQL(ltextWriter);
                }
            }
    
             protected virtual void Generate(DropColumnOperation opeRemoveColuna)
            {
                using (var ltextWriter = TextWriter())
                {
                    ltextWriter.Write("ALTER TABLE ");
                    ltextWriter.Write(RemoveDBO(opeRemoveColuna.Table));
                    ltextWriter.Write(" DROP COLUMN ");
                    ltextWriter.Write(opeRemoveColuna.Name);
    
                    ComandoSQL(ltextWriter);
                }
            }
    
            protected virtual void Generate(AlterColumnOperation opeAlteraColuna)
            {
                var lcmColuna = opeAlteraColuna.Column;
    
                using (var ltextWriter = TextWriter())
                {
                    ltextWriter.Write("ALTER TABLE ");
                    ltextWriter.Write(RemoveDBO(opeAlteraColuna.Table));
                    ltextWriter.Write(" ALTER COLUMN ");
                    ltextWriter.Write(lcmColuna.Name);
                    ltextWriter.Write(" ");
                    ltextWriter.Write(ConstruirTipoColuna(lcmColuna));
    
                    if ((lcmColuna.IsNullable != null)
                        && !lcmColuna.IsNullable.Value)
                    {
                        ltextWriter.Write(" NOT NULL");
                    }
    
                    ComandoSQL(ltextWriter);
                }
    
                if ((lcmColuna.DefaultValue == null) && string.IsNullOrWhiteSpace(lcmColuna.DefaultValueSql))
                    return;
    
                using (var ltextWriter = TextWriter())
                {
                    ltextWriter.Write("ALTER TABLE ");
                    ltextWriter.Write(RemoveDBO(opeAlteraColuna.Table));
                    ltextWriter.Write(" ALTER COLUMN ");
                    ltextWriter.Write(lcmColuna.Name);
                    ltextWriter.Write(" DROP DEFAULT");
    
                    ComandoSQL(ltextWriter);
                }
    
                using (var ltextWriter = TextWriter())
                {
                    ltextWriter.Write("ALTER TABLE ");
                    ltextWriter.Write(RemoveDBO(opeAlteraColuna.Table));
                    ltextWriter.Write(" ALTER COLUMN ");
                    ltextWriter.Write(lcmColuna.Name);
                    ltextWriter.Write(" SET DEFAULT ");
                    ltextWriter.Write(
                        (lcmColuna.DefaultValue != null)
                            ? Generate((dynamic)lcmColuna.DefaultValue)
                            : lcmColuna.DefaultValueSql
                        );
    
                    ComandoSQL(ltextWriter);
                }
            }
    
            protected virtual void Generate(DropTableOperation opeDropTable)
            {
                using (var ltextWriter = TextWriter())
                {
                    ltextWriter.Write("DROP TABLE ");
                    ltextWriter.Write(RemoveDBO(opeDropTable.Name));
    
                    ComandoSQL(ltextWriter);
                }
            }
    
            protected virtual void Generate(SqlOperation opeSQL)
            {
                ComandoSQL(opeSQL.Sql, opeSQL.SuppressTransaction);
            }
    
             protected virtual void Generate(RenameColumnOperation opeRenomearColuna)
            {
                // Inicialmente não suportada
            }
    
            protected virtual void Generate(RenameTableOperation opeRenameTable)
            {
            }
    
            protected virtual void Generate(MoveTableOperation opeMoveTable)
            {
            }
    
            private void Generate(ColumnModel cmDadosColuna, IndentedTextWriter textWriter, PrimaryKeyOperation opePrimaryKey)
            {
                textWriter.Write(cmDadosColuna.Name);
                textWriter.Write(" ");
                bool lblnEhPrimaryKey = false;
    
                if (opePrimaryKey != null)
                    lblnEhPrimaryKey = opePrimaryKey.Columns.Contains(cmDadosColuna.Name);
    
    
                if (lblnEhPrimaryKey)
                {
                    if ((cmDadosColuna.Type == PrimitiveTypeKind.Int16) ||
                        (cmDadosColuna.Type == PrimitiveTypeKind.Int32))
                        textWriter.Write(" INTEGER ");
                    else
                        textWriter.Write(ConstruirTipoColuna(cmDadosColuna));
    
                    if (cmDadosColuna.IsIdentity)
                    {
                        textWriter.Write(" PRIMARY KEY AUTOINCREMENT ");
                        pblnGerouPrimaryKey = true;
                    }
                }
                else
                {
                    textWriter.Write(ConstruirTipoColuna(cmDadosColuna));
    
                    if ((cmDadosColuna.IsNullable != null)
                        && !cmDadosColuna.IsNullable.Value)
                    {
                        textWriter.Write(" NOT NULL");
                    }
    
                    if (cmDadosColuna.DefaultValue != null)
                    {
                        textWriter.Write(" DEFAULT ");
                        textWriter.Write(Generate((dynamic)cmDadosColuna.DefaultValue));
                    }
                    else if (!string.IsNullOrWhiteSpace(cmDadosColuna.DefaultValueSql))
                    {
                        textWriter.Write(" DEFAULT ");
                        textWriter.Write(cmDadosColuna.DefaultValueSql);
                    }
                }
            }
    
            protected virtual void Generate(HistoryOperation opeHistorico)
            {
                // Foi removido, pois atualmente não usaremos o Migration
                //using (var ltextWriter = TextWriter())
                //{
                //    if (opeHistorico is InsertHistoryOperation)
                //    {
                //        InsertHistoryOperation lhisOperacaoInsert = opeHistorico as InsertHistoryOperation;
                //        ltextWriter.Write(" INSERT INTO ");
                //        ltextWriter.Write(pstrNomeTabelaMigration);
                //        ltextWriter.Write(" ( MigrationId, Model, ProductVersion) VALUES ");
                //        ltextWriter.Write(string.Format(" ('{0}', {1}, '{2}')",
                //            lhisOperacaoInsert.MigrationId,
                //            Generate(lhisOperacaoInsert.Model), lhisOperacaoInsert.ProductVersion));
                //    }
                //    else if (opeHistorico is DeleteHistoryOperation)
                //    {
                //        DeleteHistoryOperation lhisOperacaoInsert = opeHistorico as DeleteHistoryOperation;
                //        ltextWriter.Write(" DELETE FROM ");
                //        ltextWriter.Write(pstrNomeTabelaMigration);
                //        ltextWriter.Write(string.Format(" WHERE MigrationId = '{0}'",
                //            lhisOperacaoInsert.MigrationId));
                //    }
    
                //    ComandoSQL(ltextWriter);
                //}
            }
    
            protected virtual string Generate(byte[] bytDefaultValue)
            {
                var lstrbHexString = new StringBuilder();
    
                foreach (var lbtByte in bytDefaultValue)
                    lstrbHexString.Append(lbtByte.ToString("X2", CultureInfo.InvariantCulture));
    
                return "x'" + lstrbHexString + "'";
            }
            protected virtual string Generate(bool blnDefaultValue)
            {
                return blnDefaultValue ? "1" : "0";
            }
    
            protected virtual string Generate(DateTime dtmDefaultValue)
            {
                return "'" + dtmDefaultValue.ToString(pstrDefaultDateTime, CultureInfo.InvariantCulture) + "'";
            }
    
            protected virtual string Generate(DateTimeOffset dtfDefaultValue)
            {
                return "'" + dtfDefaultValue.ToString(pstrDefaultDateTime, CultureInfo.InvariantCulture) + "'";
            }
            protected virtual string Generate(Guid guidDefaultValue)
            {
                return "'" + guidDefaultValue + "'";
            }
            protected virtual string Generate(string strDefaultValue)
            {
                return "'" + strDefaultValue + "'";
            }
    
            protected virtual string Generate(TimeSpan tsDefaultValue)
            {
                return "'" + tsDefaultValue + "'";
            }
    
            protected virtual string Generate(object objDefaultValue)
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}", objDefaultValue);
            }
    
            #endregion
    
            #region Métodos auxiliares
    
            protected virtual string ConstruirTipoColuna(ColumnModel cmModeloColuna)
            {
                return cmModeloColuna.IsTimestamp ? "rowversion" : ConstruirTipoPropriedade(cmModeloColuna);
            }
    
            private string ConstruirTipoPropriedade(ColumnModel propModeloPropriedade)
            {
                var lstrOriginalStoreTypeName = propModeloPropriedade.StoreType;
    
                if (string.IsNullOrWhiteSpace(lstrOriginalStoreTypeName))
                {
                    var ltypeUsage = pprovProviderManifest.GetStoreType(propModeloPropriedade.TypeUsage).EdmType;
                    lstrOriginalStoreTypeName = ltypeUsage.Name;
                }
    
                var lstrStoreTypeName = lstrOriginalStoreTypeName;
    
                const string lstrSufixoMax = "(max)";
    
                if (lstrStoreTypeName.EndsWith(lstrSufixoMax, StringComparison.Ordinal))
                    lstrStoreTypeName = lstrStoreTypeName.Substring(0, lstrStoreTypeName.Length - lstrSufixoMax.Length) + lstrSufixoMax;
    
                switch (lstrOriginalStoreTypeName.ToLowerInvariant())
                {
                    case "decimal":
                    case "numeric":
                        lstrStoreTypeName += "(" + (propModeloPropriedade.Precision ?? pintDefaultPrecisaoNumerica)
                                         + ", " + (propModeloPropriedade.Scale ?? pintDefaultEscala) + ")";
                        break;
                    case "datetime":
                    case "time":
                        lstrStoreTypeName += "(" + (propModeloPropriedade.Precision ?? pbytDefaultPrecisaoTempo) + ")";
                        break;
                    case "blob":
                    case "varchar2":
                    case "varchar":
                    case "char":
                    case "nvarchar":
                    case "nvarchar2":
                        lstrStoreTypeName += "(" + (propModeloPropriedade.MaxLength ?? pintDefaultStringMaxLength) + ")";
                        break;
                }
    
                return lstrStoreTypeName;
            }
    
            protected void ComandoSQL(string strInstrucaoSQL, bool blnSuprimeTransacao = false)
            {
                plstComandos.Add(new MigrationStatement
                {
                    Sql = strInstrucaoSQL,
                    SuppressTransaction = blnSuprimeTransacao
                });
            }
    
            protected void ComandoSQL(IndentedTextWriter writer)
            {
                ComandoSQL(writer.InnerWriter.ToString());
            }
    
            protected static IndentedTextWriter TextWriter()
            {
                return new IndentedTextWriter(new StringWriter(CultureInfo.InvariantCulture));
            }
    
            private static string RemoveDBO(string strTexto)
            {
                return strTexto.Replace("dbo.", string.Empty);
            }
    
            private void GeraComandos(IEnumerable<MigrationOperation> lstOperacoesMigrations)
            {
                foreach (dynamic ldynOperacao in lstOperacoesMigrations)
                    Generate(ldynOperacao);
            }
    
            private void InicializaServicosProvider(string strManifestoProvider)
            {
                using (var lconConexao = CreateConnection())
                {
                    pprovProviderManifest = DbProviderServices
                        .GetProviderServices(lconConexao)
                        .GetProviderManifest(strManifestoProvider);
                }
            }
    
            protected virtual DbConnection CreateConnection()
            {
                return new SQLiteConnection();
            }
    
            private void GeraComandoCriacaoTabela(CreateTableOperation opeCriacaoTabela, IndentedTextWriter textWriter)
            {
    
                textWriter.WriteLine("CREATE TABLE " + RemoveDBO(opeCriacaoTabela.Name) + " (");
                textWriter.Indent++;
    
                for (int i = 0; i < opeCriacaoTabela.Columns.Count; i++)
                {
                    ColumnModel lcmDadosColuna = opeCriacaoTabela.Columns.ToList()[i];
                    Generate(lcmDadosColuna, textWriter, opeCriacaoTabela.PrimaryKey);
    
                    if (i < opeCriacaoTabela.Columns.Count - 1)
                        textWriter.WriteLine(",");
                }
    
                if ((opeCriacaoTabela.PrimaryKey != null) && !pblnGerouPrimaryKey)
                {
                    textWriter.WriteLine(",");
                    textWriter.Write("CONSTRAINT ");
                    textWriter.Write(RemoveDBO(opeCriacaoTabela.PrimaryKey.Name));
                    textWriter.Write(" PRIMARY KEY ");
                    textWriter.Write("(");
    
                    for (int li = 0; li < opeCriacaoTabela.PrimaryKey.Columns.Count; li++)
                    {
                        var lstrNomeColuna = opeCriacaoTabela.PrimaryKey.Columns[li];
    
                        textWriter.Write(lstrNomeColuna);
    
                        if (li < opeCriacaoTabela.PrimaryKey.Columns.Count - 1)
                            textWriter.WriteLine(",");
                    }
    
                    textWriter.WriteLine(")");
                }
                else
                {
                    textWriter.WriteLine();
                }
    
                textWriter.Indent--;
                textWriter.Write(")");
            }
    
            #endregion
    
        }
    }
