    // Create DataSet and load data
    DataSet ParentData = new DataSet();
    ParentData.ReadXml(Server.MapPath("ParentFile.xml"));
    // Create SqlBulkCopy object
    SqlConnection connection = new SqlConnection("YourConnectionString");
    SqlBulkCopy bulkCopy = new SqlBulkCopy(connection);
    bulkCopy.DestinationTableName = "YourParentTable";
    // Get DataTable and copy it to database
    DataTable ParentTable = ParentData.Tables["Parent"];
    bulkCopy.WriteToServer(ParentTable);
