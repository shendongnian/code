    var parameters = new string[k_p.Count];
    using(var cmd = new SqlCommand())
    {
        for (int i = 0; i < k_p.Count; i++)
        {
            parameters[i] = string.Format("@id_p{0}", i);
            cmd.Parameters.AddWithValue(parameters[i], k_p[i]);
        }
        var sql = "Select Proizvod.id_p, Proizvod.ime, TipProizvoda.tip, Proizvod.dimenzije, Proizvod.cijena FROM Proizvod LEFT JOIN TipProizvoda ON Proizvod.tip=TipProizvoda.id_t WHERE Proizvod.id_p IN ({0})";
        cmd.CommandText = string.Format(sql, string.Join(", ", parameters));
        using(var con = new SqlConnection(connStr))
        {
            cmd.Connection = con;
            using(var da = new SqlDataAdapter(cmd))
            {
                // ...
            }
        }
    }
