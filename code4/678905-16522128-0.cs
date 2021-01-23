    public class MyCustomNamingStrategy : INamingStrategy
    {
        public MyCustomNamingStrategy(IDictionary<string, string> properties)
        {
             _properties = properties;
        }
        public string TableName(string tableName)
        {
            tableName = tableName.Replace("[customPart]", _properties["foo"]);
            return DefaultNamingStrategy.Instance.TableName(tableName);
        }
    
        public string ClassToTableName(string className) { return DefaultNamingStrategy.Instance.ClassToTableName(className); }
        public string PropertyToColumnName(string propertyName) { return DefaultNamingStrategy.Instance.PropertyToColumnName(propertyName); }
        public string ColumnName(string columnName) { return DefaultNamingStrategy.Instance.ColumnName(columnName); }
        public string PropertyToTableName(string classNme, string propertyName) { return DefaultNamingStrategy.Instance.PropertyToTableName(className, propertyName); }
        public string LogicalColumnName(string columnName, string propertyName) { return DefaultNamingStrategy.Instance.LogicalColumnName(columnName, propertyName); }
    }
