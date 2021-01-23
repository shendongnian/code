        public ActionResult writeRecord()
        {
    
            Response.Write("Survey Completed!");
            SqlConnection conn = DBTools.GetDBConnection("ApplicationServices2");
    
    
            string sqlquery = "SELECT Q1, Q2, Q3, Q4, Improvements, Comments FROM myTable";
            SqlDataAdapter cmd = new SqlDataAdapter(sqlquery, conn);
    
            DataSet myData = new DataSet();
            cmd.Fill(myData, "myTable");
 
    
            conn.Open();
            conn.Close();
            return Json(myData, JsonRequestBehaviour.AllowGet);
    
        } 
