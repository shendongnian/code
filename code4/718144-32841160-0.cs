    string status = "ABC";
            DataColumn dc = new DataColumn("Status");
            dt.Columns.Add(dc);
            foreach (DataRow dr in dt.Rows)
            {
                dr["status"]= status;
            }
            return dt;
