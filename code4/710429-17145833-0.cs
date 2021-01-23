using (SqlConnection conn  = new SqlConnection())
{
    conn.Open();
    Sqlmd.Connection = conn;
    SqlDataAdapter da = new SqlDataAdapter(Sqlmd);
   //...etc
}
