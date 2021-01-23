     public static string EstadoToAlias(eEstado value)
     {
        switch(value)
        {
            case eEstado.Active: return "Activo";
            case eEstado.Inactive: return "Inactivo";
            default: throw new ArgumentException(value);
        }
     }
