    try
    {
       StringWriter sw = new StringWriter();
                        
       //ds.WriteXml(sw, XmlWriteMode.IgnoreSchema);
       DataTable dt = ds.Tables[0];
       sw.Write(@"<NewDataSet>");
       foreach (DataRow row in dt.Rows)
       {
          sw.Write(@"<Table>");
          foreach (DataColumn col in dt.Columns)
          {
             sw.Write(@"<" + XmlConvert.EncodeName(col.ColumnName) + @">");
             sw.Write(row[col]);
             sw.Write(@"</" + XmlConvert.EncodeName(col.ColumnName) + @">");
          }
          sw.Write(@"</Table>");
       }
       sw.Write(@"</NewDataSet>");
       return sw.ToString();
    }
    catch (Exception ex)
    {
       return ex.ToString();
    }
