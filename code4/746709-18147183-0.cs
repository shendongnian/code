    public static class CustomSqlTypeHelpers
    {
        static readonly string _ClobSqlType;
        static CustomSqlTypeHelpers()
        {
            // Checks to validate config file setting ommitted
            _ClobSqlType = ConfigurationManager.AppSettings["ClobSqlType"];
        }
        public static PropertyPart LargeTextColumn(this PropertyPart pp)
        {
            return pp.CustomSqlType(_ClobSqlType);
        }
    }
    public FileTemplateMap()
    {
        Table("FILE_TEMPLATE");
        Map(f => f.Xml, "XML").LargeTextColumn()
    }
