    // Create a DataSet with one table containing two columns.
    DataSet dataSet = new DataSet("dataSet");
    DataTable table = dataSet.Tables.Add("string");
    table.Columns.Add("PFOID", typeof(string));
    table.Columns.Add("Quantity", typeof(value));
    DataRow row;
    row = table.NewRow();
    row["PFOID"]= "04676723-2afb-49ff-9fa1-0131cabb407c";
    row["Quantity"]= 90;
    table.Rows.Add(row);
    // Display the DataSet contents as XML.
    Console.WriteLine(dataSet.GetXml());
