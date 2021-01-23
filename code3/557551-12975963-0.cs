     public DataTable GetDataTableFromTextFile(string filepath) 
        {
                                    string line;
                                    DataTable dt = new DataTable();                         
                                    using (TextReader tr = File.OpenText(filepath))
                                    {
                                        while ((line = tr.ReadLine()) != null)
                                        {
                                            string[] items = line.Split('\t',":",";","=");
                                            if (dt.Columns.Count == 0)
                                            {
                                                dt.Columns.Add(new DataColumn("FirstColumn", typeof(string)));
                                                dt.Columns.Add(new DataColumn("SecondColumn", typeof(string)));
                                                dt.Columns.Add(new DataColumn("ThridColumn", typeof(string)));
    
                                            }
    
                                            if (items.Length > 0 && !string.IsNullOrWhiteSpace(items[0].ToString()))
                                            {
                                                dt.Rows.Add(items);                                       
                                            }
                                        }
                                    }
        return dt;
    
    }
