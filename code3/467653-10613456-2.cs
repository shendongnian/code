    // a list of datatables each containing 1 row, wasn't that the point of datatables
        // anyway -- I think you don't have any rows, so let's try this:
        private String ConvertNullToEmptyString(DataTable element)
        {
            if (element.Rows.Count == 0)
            {
                return "NO DATA";
            }
            if (element.Rows[0]["Fullname"] == DBNull.Value || element.Rows[0]["Fullname"] == null)
            {
                return "NO DATA";
            }
            else
            {
                return element.Rows[0]["Fullname"].ToString();
            }
        } 
        protected void Test()
        {
            List<DataTable> strList = new List<DataTable>(){ 
               GetItem("test1"),   //private DataTable GetItem1(String t) 
               GetItem("test2")   //...            
             };
            txtGrD_D.Text = ConvertNullToEmptyString(strList[0]);
        }
        
