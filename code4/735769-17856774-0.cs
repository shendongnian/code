    SqlConnection CN = new SqlConnection(constring);
    string Query = "Update test Set name=@Name,image=@Image where id=@id"
    CN.Open();
    cmd = new SqlCommand(Query, CN);
    cmd.Parameters.Add(new SqlParameter("@Image", img));
    cmd.Parameters.Add(new SqlParameter("@Name",txtname.Text));
    cmd.Parameters.Add(new SqlParameter("@id",txtid.Text));
    cmd.ExecuteNonQuery();
    CN.Close();
