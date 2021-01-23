    public class BorradoUsuarioTrigger : AbstractAuxiliaryDatabaseObject
    {
        public override string SqlCreateString(Dialect dialect, IMapping p, string defaultCatalog, string defaultSchema){
        //The drop is important, because the shema export calls and executes this twice.   
        this.Parameters.Add("idHist", "(SELECT IdHistorialEstado FROM Usuarios WHERE IdUsuario = OLD.IdUsuario)");
        this.Parameters.Add("idDom", "(SELECT IdDomicilio FROM Usuarios WHERE IdUsuario = OLD.IdUsuario)");
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("DROP TRIGGER IF EXISTS borradoUsuarioTrigger;");
        builder.AppendLine("CREATE TRIGGER borradoUsuarioTrigger BEFORE DELETE ON activaciones FOR EACH ROW ");
        builder.AppendLine("BEGIN ");
        builder.AppendLine("DELETE FROM domicilios WHERE IdDomicilio = " + this.Parameters["idDom"] + "; ");
        builder.AppendLine("DELETE FROM historialestado WHERE IdHistorialEstado = " + this.Parameters["idHist"] + "; ");
        builder.AppendLine("DELETE FROM detallehistorialestado WHERE idHistorialEstado = " + this.Parameters["idHist"] + "; ");
        builder.AppendLine("DELETE FROM inmobiliarias WHERE IdInmobiliaria = OLD.idUsuario; ");
        builder.AppendLine("DELETE FROM particulares WHERE IdParticular = OLD.idUsuario; ");
        builder.AppendLine("DELETE FROM moderadores WHERE IdModerador = OLD.idUsuario; ");
        builder.AppendLine("DELETE FROM usuarios WHERE IdUsuario = OLD.idUsuario; ");
        builder.AppendLine("END ");
        return builder.ToString();
        }
        public override string SqlDropString(Dialect dialect, string defaultCatalog, string defaultSchema)
        {
            return @"DROP TRIGGER IF EXISTS borradoUsuarioTrigger";
        }
        public void AddDialectScope(string dialectName)
        {
            throw new NotImplementedException();
        }
        public bool AppliesToDialect(Dialect dialect)
        {
            return true;
        }
        public void SetParameterValues(IDictionary<string, string> parameters)
        {
            base.SetParameterValues(parameters);
        }
    }
