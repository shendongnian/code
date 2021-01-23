     public List<SelectListItem> Teams
            {
                get 
                {
    
                    string SQLSelect = ("SELECT * FROM Teams");
                    OleDbCommand sCommand = new OleDbCommand(SQLSelect, connector);
                    Adaptor.SelectCommand = sCommand;
    
    
                    connector.Open();
                    Adaptor.Fill(areaTable);
                    connector.Dispose();
    
                    foreach (DataRow row in areaTable.Rows)
                    {
                        _Team.Add(new SelectListItem() { Text = row[1].ToString(), Value = row[1].ToString() });
                       
                    }
    
                    return _Team;
                }
            }
