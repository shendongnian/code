     public static StringBuilder XMLNodeListToStringBuilderConverter(XmlNodeList xmlNodeList, string separator)
       {
           try
           {
               StringBuilder sb = new StringBuilder();
               DataTable dt = new DataTable();
               foreach (XmlNode node in xmlNodeList.Item(0).ChildNodes) 
               {
                   DataColumn dc = new DataColumn(node.FirstChild.InnerText, System.Type.GetType("System.String"));
                   dt.Columns.Add(dc);
               }
               int ColumnsCount = dt.Columns.Count;
               string[] columnNames = dt.Columns.Cast<DataColumn>().
                                                 Select(column => column.ColumnName).
                                                 ToArray();
               sb.AppendLine(string.Join(separator, columnNames));
               string[] rows = new string[ColumnsCount];
               for (int i = 1; i < xmlNodeList.Count; i++) // loop through rows
               {
                   for (int j = 0; j < ColumnsCount; j++) // loop through columns
                   {
                       rows[j] = xmlNodeList.Item(i).ChildNodes[j].InnerText.Replace(separator, ",").Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " "); // remove seperator from original text, it will casue problem 
                       
                   }
                   sb.AppendLine(string.Join(separator, rows));
                   Array.Clear(rows, 0, ColumnsCount);
               }
               return sb;
           }
           catch (Exception)
           {
            
               throw;
           }
       }
