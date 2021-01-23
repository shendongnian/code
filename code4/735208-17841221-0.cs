    public void test() {
            List<string> ListLinkedIds = new List<string>(); //This has values such as 6, 8, etc.
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            //Removes from DataTable 
            for (int x = 0; x < ListLinkedIds.Count(); x++)
            {
                DataRow[] matches = dt.Select("ID='" + ListLinkedIds[x] + "'");
                foreach (DataRow row in matches) {
                    dt.Rows.Remove(row);
                }
            }
        
        }
