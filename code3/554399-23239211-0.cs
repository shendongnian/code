        private static DataSet ImportExcelXML(Stream inputFileStream, bool hasHeaders)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(new XmlTextReader(inputFileStream));
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("o", "urn:schemas-microsoft-com:office:office");
        nsmgr.AddNamespace("x", "urn:schemas-microsoft-com:office:excel");
        nsmgr.AddNamespace("ss", "urn:schemas-microsoft-com:office:spreadsheet");
        DataSet ds = new DataSet();
        foreach (XmlNode node in
          doc.DocumentElement.SelectNodes("//ss:Worksheet", nsmgr))
        {
            DataTable dt = new DataTable(node.Attributes["ss:Name"].Value);
            ds.Tables.Add(dt);
            XmlNodeList rows = node.SelectNodes("ss:Table/ss:Row", nsmgr);
            if (rows.Count > 0)
            {
                //*************************
                //Add Columns To Table from header row
                //*************************
                List<ColumnType> columns = new List<ColumnType>();
                int startIndex = 0;
                if (hasHeaders)
                {
                    foreach (XmlNode data in rows[0].SelectNodes("ss:Cell/ss:Data", nsmgr))
                    {
                        columns.Add(new ColumnType(typeof(string)));//default to text
                        dt.Columns.Add(data.InnerText, typeof(string));
                    }
                    startIndex++;
                }
                //*************************
                //Update Data-Types of columns if Auto-Detecting
                //*************************
                if (rows.Count > 0)
                {
                    XmlNodeList cells = rows[startIndex].SelectNodes("ss:Cell", nsmgr);
                    int actualCellIndex = 0;
                    for (int cellIndex = 0; cellIndex < cells.Count; cellIndex++)
                    {
                        XmlNode cell = cells[cellIndex];
                        if (cell.Attributes["ss:Index"] != null)
                            actualCellIndex =
                              int.Parse(cell.Attributes["ss:Index"].Value) - 1;
                        //ColumnType autoDetectType =
                        //  getType(cell.SelectSingleNode("ss:Data", nsmgr));
                        if (actualCellIndex >= dt.Columns.Count)
                        {
                            //dt.Columns.Add("Column" +
                            //  actualCellIndex.ToString(), autoDetectType.type);
                            dt.Columns.Add("Column" + actualCellIndex.ToString());
                            //columns.Add(autoDetectType);
                        }
                        else
                        {
                            //dt.Columns[actualCellIndex].DataType = autoDetectType.type;
                            //columns[actualCellIndex] = autoDetectType;
                        }
                        actualCellIndex++;
                    }
                }
                //*************************
                //Load Data
                //*************************
                for (int i = startIndex; i < rows.Count; i++)
                {
                    DataRow row = dt.NewRow();
                    XmlNodeList cells = rows[i].SelectNodes("ss:Cell", nsmgr);
                    int actualCellIndex = 0;
                    for (int cellIndex = 0; cellIndex < cells.Count; cellIndex++)
                    {
                        XmlNode cell = cells[cellIndex];
                        if (cell.Attributes["ss:Index"] != null)
                            actualCellIndex = int.Parse(cell.Attributes["ss:Index"].Value) - 1;
                        XmlNode data = cell.SelectSingleNode("ss:Data", nsmgr);
                        if (actualCellIndex >= dt.Columns.Count)
                        {
                            for (int ii = dt.Columns.Count; ii < actualCellIndex; ii++)
                            {
                                //dt.Columns.Add("Column" + actualCellIndex.ToString(), typeof(string)); columns.Add(getDefaultType());
                                dt.Columns.Add("Column" + actualCellIndex.ToString());
                                //columns.Add(getDefaultType());
                            } // ii
                            //ColumnType autoDetectType = getType(cell.SelectSingleNode("ss:Data", nsmgr));
                            dt.Columns.Add("Column" + actualCellIndex.ToString(),
                                           typeof(string));
                            // columns.Add(autoDetectType);
                        }
                        if (data != null)
                            row[actualCellIndex] = data.InnerText;
                        actualCellIndex++;
                    }
                    dt.Rows.Add(row);
                }
            }
        }
        return ds;
    }
