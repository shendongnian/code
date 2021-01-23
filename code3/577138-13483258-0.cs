    public JsonResult getData(int start, int limit)
    {
        DataTable dt = new DataTable();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices1"].ConnectionString))
        {
            using (SqlCommand cmd = cnn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT State, Capital FROM MYDBTABLE";
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
        }
        List<MyItem> items  = (from DataRow row in dt.Rows
                               select new MyItem
                               {
                               		State = row["State"].ToString(),
                                    Capital = row["Capital"].ToString()
                               }).Skip(start - 1).Take(limit).ToList();
        return Json(new {  myTable = items }, JsonRequestBehavior.AllowGet);
    }
