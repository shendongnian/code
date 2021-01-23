    //Build DataTable for the purposes of this Example:
    DataTable dt = new DataTable();
    //Add Columns:
    dt.Columns.Add("WidgetType");//The default Type is "string".
    dt.Columns.Add("WidgetID", typeof(int));
    dt.Columns.Add("WidgetName");
    dt.Columns.Add("WidgetPrice", typeof(decimal));
    dt.Columns.Add("SubWidget");
    //Add Rows:
    dt.Rows.Add("Watch",  1, "Dial",     .50, "Gear");
    dt.Rows.Add("Tablet", 2, "Screen", 14.99, null);
    dt.Rows.Add("Watch",  3, "Strap",   1,    "Buckle");
    //Prep XML Objects:
    XDocument xDoc = new XDocument();
    //xDoc.Declaration = new XDeclaration("1.0", "utf-16", null);//Optional: SQL-Server already stores XML using UTF-16.  The default for XDocument is also UTF-16 when the Declaration is null. - 07/26/2018 - MCR.
    XElement xRoot = new XElement("Root");
    xRoot.SetAttributeValue("Date", string.Format("{0:MM/dd/yyyy hh:mm tt}", DateTime.Now));//Optional: Add Attribute to Root.
    //Populate XML from DataTable:
    xRoot.Add(dt.AsEnumerable()
                //.Where(r => r.Field<string>("WidgetType") == "Watch")//Optional: Add Filter.  This works.
                .Select(r => new XElement(r.Field<string>("WidgetType"),//Add Row Element
                                          //r.Field<decimal>("WidgetPrice"),//Optional: Populate Element Value.
                                          new XAttribute("WidgetID",   r.Field<int>("WidgetID")),//Optional: Add Attribute.
                                          new XAttribute("WidgetName", r.Field<string>("WidgetName")),//Optional: Add Attribute.
                                          new XElement("SubWidget", r.Field<string>("SubWidget"))//Optional: Add Child-Element.
                                         )
                       )
             );
    //Finish assembling the XML:
    xDoc.Add(xRoot);
    //View the XML Data:
    string sDoc = xDoc.ToString();//View Indented-XML as a string.
    //View the XML as it would appear in a Standalone File:
    System.IO.StringWriter sw = new System.IO.StringWriter();
    xDoc.Save(sw);
    string sWrite = sw.ToString();//This adds the XML Declaration to the string output.
