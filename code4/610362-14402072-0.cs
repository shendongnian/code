    DataTable dt = new DataTable();
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    var satAvail = row[column];
                }
            }
