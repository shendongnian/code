    public class MyConnection : DbConnection
    {
        ...
        public override void Open()
        {
            using (SqlCommand cmd = new SqlCommand("SET ANSI_NULLS OFF", (SqlConnection)this.WrappedConnection))
            {
                cmd.ExecuteNonQuery();
            }
        }
        ...
    }
