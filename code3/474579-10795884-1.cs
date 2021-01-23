    DataSet reportData = new DataSet();
    reportData.ReadXml(Server.MapPath("yourfile.xml"));
    SqlConnection connection = new SqlConnection("DB ConnectionSTring");
    SqlBulkCopy sbc = new SqlBulkCopy(connection);
    sbc.DestinationTableName = "yourXMLTable";
