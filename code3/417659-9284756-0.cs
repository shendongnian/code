    // Create a DataSet, DataTable, and define a binary column
    DataSet dataSet = new DataSet("dataSet");
    DataTable table = dataSet.Tables.Add("Items");
    table.Columns.Add("image", typeof(byte[]));
    
    /// Add one row of binary data (creating fake binary data from a string)
    byte[] testData = new ASCIIEncoding().GetBytes("StackOverflow");
    Console.WriteLine("Test data: " + new ASCIIEncoding().GetString(testData));
    DataRow row = table.NewRow();
    row["image"] = testData;
    table.Rows.Add(row);
    
    // Convert to XML and fetch the XML representation of the binary data
    string xml = dataSet.GetXml();
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    string xmlImageData = doc.SelectSingleNode("//image").InnerText;
    Console.WriteLine("XML data: " + xmlImageData);
    
    // base64decode the XML data and print its value
    byte[] decoded = Convert.FromBase64String(xmlImageData);
    Console.WriteLine("Decoded data: " + new ASCIIEncoding().GetString(decoded));
