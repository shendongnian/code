    List<string> entries = new List<string>();
    String rawXML = item.OptBox_Options;
    StringReader stream = null;
    XmlTextReader reader = null;
    DataSet xmlDS = new DataSet();
    stream = new StringReader(rawXML);
    // Load the XmlTextReader from the stream
    reader = new XmlTextReader(stream);
    xmlDS.ReadXml(reader);
    DataSet myOPTvalues = new DataSet();
    myOPTvalues = xmlDS;
    foreach (DataRow row in myOPTvalues.Tables[0].Rows)
    {
        var optItem = new PrevzemSpin();
        optItem.FieldValue = row["FieldValue"].ToString();
        if (optItem.FieldValue.Equals("")) optItem.FieldValue = null;
        optItem.FieldTextValue = row["FieldTextValue"].ToString();
        if (optItem.FieldTextValue.Equals("")) optItem.FieldTextValue = null;
        entries.Add(optItem.FieldTextValue);
        SpinnerValue.Tag = optItem.FieldValue;
    }
