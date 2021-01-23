    //Define your webtable
    public static HtmlTable table
                {
                    get
                    {
                        HtmlTable var = new HtmlTable(parent);
                        var.SearchProperties.Add("id", "searchId");
                        return var;
                    }
                }
    //Convert a webtable to datatable
    public static DataTable getTable
                {
                    get
                    {
                        DataTable dtTable= new DataTable("TableName");
                        UITestControlCollection rows = table.Rows;
                        UITestControlCollection headers = rows[0].GetChildren();
                        foreach (HtmlHeaderCell header in headers)
                        {
                            if (header.InnerText != null)
                                dtTable.Columns.Add(header.InnerText);
                        }
                        for (int i = 1; i < rows.Count; i++)
                        {
                            UITestControlCollection cells = rows[i].GetChildren();
                            string[] data = new string[cells.Count];
                            int counter = 0;
                            foreach (HtmlCell cell in cells)
                            {
                                if (cell.InnerText != null)
                                    data[counter] = cell.InnerText;
                                counter++;
                            }
                            dtTable.Rows.Add(data);
                        }
                        return dtTable;
                    }
                }
