    using System;
    using System.Data;
    using System.Data.Common;
    using System.Reflection;
    using NHibernate;
    using NHibernate.AdoNet;
    using NHibernate.Driver;
    using NHibernate.Engine.Query;
    using NHibernate.SqlTypes;
    using NHibernate.Util;
    using Oracle.DataAccess.Client;
    /// <summary>
    ///   A NHibernate Driver for using the Oracle.DataAccess DataProvider
    /// </summary>
    /// <remarks>
    ///   Code was contributed by <a href="http://sourceforge.net/users/jemcalgary/">James Mills</a> on the NHibernate forums in this <a
    ///    href="http://sourceforge.net/forum/message.php?msg_id=2952662">post</a> .
    /// </remarks>
    public class CustomOracleDataClientDriver : ReflectionBasedDriver, IEmbeddedBatcherFactoryProvider {
        private const string DriverAssemblyName = "Oracle.DataAccess";
        private const string ConnectionTypeName = "Oracle.DataAccess.Client.OracleConnection";
        private const string CommandTypeName = "Oracle.DataAccess.Client.OracleCommand";
        private static readonly SqlType GuidSqlType = new SqlType(DbType.Binary, 16);
        private readonly PropertyInfo oracleDbType;
        private readonly object oracleDbTypeRefCursor;
        private readonly object oracleDbTypeXmlType;
    
        /// <summary>
        ///   Initializes a new instance of <see cref="OracleDataClientDriver" /> .
        /// </summary>
        /// <exception cref="HibernateException">Thrown when the
        ///   <c>Oracle.DataAccess</c>
        ///   assembly can not be loaded.</exception>
        public CustomOracleDataClientDriver()
            : base(
                DriverAssemblyName,
                ConnectionTypeName,
                CommandTypeName) {
            var parameterType = ReflectHelper.TypeFromAssembly("Oracle.DataAccess.Client.OracleParameter",
                DriverAssemblyName, false);
            this.oracleDbType = parameterType.GetProperty("OracleDbType");
    
            var oracleDbTypeEnum = ReflectHelper.TypeFromAssembly("Oracle.DataAccess.Client.OracleDbType",
                DriverAssemblyName, false);
            this.oracleDbTypeRefCursor = Enum.Parse(oracleDbTypeEnum, "RefCursor");
            this.oracleDbTypeXmlType = Enum.Parse(oracleDbTypeEnum, "XmlType");
        }
    
        /// <summary>
        /// </summary>
        public override bool UseNamedPrefixInSql {
            get { return true; }
        }
    
        /// <summary>
        /// </summary>
        public override bool UseNamedPrefixInParameter {
            get { return true; }
        }
    
        /// <summary>
        /// </summary>
        public override string NamedPrefix {
            get { return ":"; }
        }
    
        #region IEmbeddedBatcherFactoryProvider Members
    
        Type IEmbeddedBatcherFactoryProvider.BatcherFactoryClass {
            get { return typeof (OracleDataClientBatchingBatcherFactory); }
        }
    
        #endregion
    
        /// <remarks>
        ///   This adds logic to ensure that a DbType.Boolean parameter is not created since ODP.NET doesn't support it.
        /// </remarks>
        protected override void InitializeParameter(IDbDataParameter dbParam, string name, SqlType sqlType) {
            // if the parameter coming in contains a boolean then we need to convert it 
            // to another type since ODP.NET doesn't support DbType.Boolean
            switch (sqlType.DbType) {
                case DbType.Boolean:
                    base.InitializeParameter(dbParam, name, SqlTypeFactory.Int16);
                    break;
                case DbType.Guid:
                    base.InitializeParameter(dbParam, name, GuidSqlType);
                    break;
                case DbType.Xml:
                    dbParam.ParameterName = this.FormatNameForParameter(name);
                    this.oracleDbType.SetValue(dbParam, this.oracleDbTypeXmlType, null);
                    break;
                default:
                    base.InitializeParameter(dbParam, name, sqlType);
                    break;
            }
        }
    
        protected override void OnBeforePrepare(IDbCommand command) {
            base.OnBeforePrepare(command);
    
            ((OracleCommand) command).BindByName = true;
    
            var detail = CallableParser.Parse(command.CommandText);
    
            if (!detail.IsCallable)
                return;
    
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = detail.FunctionName;
    
            var outCursor = command.CreateParameter();
            this.oracleDbType.SetValue(outCursor, this.oracleDbTypeRefCursor, null);
    
            outCursor.Direction = detail.HasReturn ? ParameterDirection.ReturnValue : ParameterDirection.Output;
    
            command.Parameters.Insert(0, outCursor);
        }
    }
