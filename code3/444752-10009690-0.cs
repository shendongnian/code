    DataView view = new DataView(Datatble);
    int viewcount = view.Count;
                    
                    
    DataTable distinctValues = view.ToTable(true, "SurNameEnglish", "HouseNumber");
    int distinctcount = distinctValues.Rows.Count;
    
    int cnt = 1;
     for (int j = 0; j < distinctcount; j++)
                    {
                        
                        string surname = distinctValues.Rows[j]["SurNameEnglish"].ToString();
                        string Housenumber = distinctValues.Rows[j]["HouseNumber"].ToString();
                        for (int i = 0; i < viewcount; i++)
                        {
                            if (Datatble.Rows[i]["SurNameEnglish"].Equals(surname) && Datatble.Rows[i]["HouseNumber"].Equals(Housenumber))
                            {
                            
    
    
                                Datatble.Rows[i]["Family"] = cnt;
                                Datatble.AcceptChanges();
                               
                            }
                        }
                        cnt++;
    
                    }
    
    }
