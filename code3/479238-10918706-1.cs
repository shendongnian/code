    using (SqlConnection con = new SqlConnection(DBHelper.connection))
    {
      using(SqlCommand com = con.CreateCommand())
      {
       con.Open();
       com.CommandType = CommandType.Text;
       com.CommandText = "select catname,catdescription,photo from category where catid=" + catselectddl.SelectedValue ;
       SqlDataReader dr= com.ExecuteReader();
       DataTable dt = new DataTable();
       dt.Load(dr);
       DataRow drr;
       drr=dt.Rows[0];
       }
     }
