    public Client getClient(int idClient)
    {
        var c = new Client();
        using (var sql = new SqlConnection(@"Data Source=GRIGORE\SQLEXPRESS;Initial Catalog=testWCF;Integrated Security=True"))
        {
            sql.Open();
            using (var cmd = new SqlCommand("Select * from Clienti where id = " + idClient, sql))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        c.idClient = int.Parse(dr["id"].ToString());
                        c.numeClient = dr["nume"].ToString();
                    }
                }
            }
        }
        return c;
    }
