    TableEntity : BaseEntity
    {
        string TableName { get; set; }
        List<TableDataEntity> Data { get; set; }
        TableEntity(MySqlDataAdapter dataAdapter)
        {
            //convert dataAdapter into TableEntity properties
        }
    }
