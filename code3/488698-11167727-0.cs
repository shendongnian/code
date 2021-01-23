     private DataTable TestCreateDataTable()
                {
                    DataTable dt = new DataTable();
        
                    dt.Columns.Add("SeasonId", typeof(int));     // seasonId and then
                    dt.Columns.Add("SeasonName", typeof(string)); // seasonName
                    dt.Columns.Add("Month", typeof(int));
                    dt.Columns.Add("IsDeleted", typeof(bool));
                    dt.Rows.Add("season1",1, 4,  false);
                    dt.Rows.Add("season2",2, 9, false);
                    dt.Rows.Add("season3",3, 11,  false);
                    return dt;
                }
 
