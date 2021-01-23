    DilbertSoapClient client = new DilbertSoapClient();
    string s = client.DailyDilbert(DateTime.Now);
    DataTable table = new DataTable();
    StringReader reader = new StringReader(s);
    table.ReadXml(reader);
    foreach (DataRow row in table.Rows)
    {
        // do something with the row
    }
