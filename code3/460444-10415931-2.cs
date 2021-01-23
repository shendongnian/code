        [WebMethod]
        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Col1", typeof(string));
            dt.Rows.Add("testing");
            dt.TableName = "Blah";  // <---
            return dt;
        }
