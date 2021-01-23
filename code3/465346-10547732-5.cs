public static DataTable GetDataTable(string sConnStr, string sTable)
{    
   DataTable dt = new DataTable();
   try
   {
       using (SqlConnection sqlConn10 = new SqlConnection(sConnStr))
       using (SqlCommand sqlComm10 = new SqlCommand("SELECT * FROM " + sTable, sqlConn10))
       {
           sqlConn10.Open();
           using (SqlDataReader myReader10 = sqlComm10.ExecuteReader())
           {                     
               dt.Load(myReader10);
           }
       }
   }
   catch(Exception ex)
   {
   }
   return dt;
}
