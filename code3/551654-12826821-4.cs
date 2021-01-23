    public static bool randomgen() 
    {
        bool isFound = false;
        string admissionNumber = "SN " + r.Next(100); 
        HttpContext.Current.Session["number"] = admissionNumber; 
        using (SqlConnection con = new SqlConnection()) // use "using" to guarantee connection is closed
        {
            string sql1 = "SELECT CASE WHEN EXISTS(SELECT admissionno FROM tlblstudent_details WHERE admissionno = @admissionno) THEN 1 ELSE 0 END";
            using (SqlCommand cmd = con.CreateCommand(sql1))
            {
                 cmd.Parameters.AddWithValue("@admissionno", number);
                 using (SqlDataReader dr = cmd.ExecuteReader())
                 {
                     if (dr.Read())
                     {
                         isFound = (Convert.ToInt32(dr[0]) == 1)
                      }
                  }
             }
         }
         return isFound;
    }
