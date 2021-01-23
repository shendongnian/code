     public DataTable GetColumnsFromXML(String XMLPath, String TableName)
    {
        DataTable dtForColumns = DatatableforColumns();
        XmlDataDocument xmldoc = new XmlDataDocument();
        xmldoc.Load(XMLPath);
        XmlElement root = xmldoc.DocumentElement;
        XmlNodeList tablenodes = root.SelectNodes("Table");
        if (tablenodes != null)
            foreach (XmlNode nodes in tablenodes)
            {
                if (!nodes.HasChildNodes) continue;
                if (nodes.Attributes == null) continue;
                //TableName = nodes.Attributes[0].Value;
                if (nodes.Attributes[0].Value == TableName)
                {
                    String PrimaryKey = nodes.Attributes[1].Value;
                    var nodesdisplayname = nodes.SelectNodes("Column/DisplayColumn");
                    var nodesorignalvalue = nodes.SelectNodes("Column/OrignalColumn");
                   
                    if (nodesdisplayname != null && nodesorignalvalue != null)
                    {
                        for (int i = 0; i <= nodesdisplayname.Count - 1; i++)
                        {
                            var xmlDisplayNode = nodesdisplayname.Item(i);
                            var xmlOrignalNode = nodesorignalvalue.Item(i);
                            
                   
                            if (xmlDisplayNode != null && xmlOrignalNode != null)
                            {
                                DataRow dr;
                                dr = dtForColumns.NewRow();
                                dr["DisplayColumn"] = xmlDisplayNode.InnerText;
                                dr["OrignalColumn"] = xmlOrignalNode.InnerText;
                                dr["PrimaryKey"] = PrimaryKey;
                                dtForColumns.Rows.Add(dr);
                            }
                        }
                    }
                }
            }
        return dtForColumns;
    }
    private DataTable DatatableforColumns()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("DisplayColumn", typeof(String));
        dt.Columns.Add("OrignalColumn", typeof(String));
        dt.Columns.Add("PrimaryKey", typeof(String));
        return dt;
    }
    
