    public static DynamicModel Open(string connectionString, string providerName="System.Data.SqlClient") 
    {
            dynamic dm = new DynamicModel(connectionString, providerName);
            return dm;
    }
    
    public DynamicModel(string connectionString, string providerName ="System.Data.SqlClient", string tableName = "", 
         string primaryKeyField = "", string descriptorField = "") 
    {
            TableName = tableName == "" ? this.GetType().Name : tableName;
            PrimaryKeyField = string.IsNullOrEmpty(primaryKeyField) ? "ID" : primaryKeyField;
            DescriptorField = descriptorField;
            
            _factory = DbProviderFactories.GetFactory(providerName);
            ConnectionString = connectionString;
    }
