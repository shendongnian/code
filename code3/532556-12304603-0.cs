    var parameters = new string[k_p.Count];
    using(var cmd = new SqlCommand())
    {
        for (int i = 0; i < k_p.Count; i++)
        {
            parameters[i] = string.Format("@id_p{0}", i);
            cmd.Parameters.AddWithValue(parameters[i], k_p[i]);
        }
        
        cmd.CommandText = string.Format("Select Proizvod.id_p, Proizvod.ime, TipProizvoda.tip, Proizvod.dimenzije, Proizvod.cijena FROM Proizvod LEFT JOIN TipProizvoda ON Proizvod.tip=TipProizvoda.id_t WHERE Proizvod.id_p IN ({0})", string.Join(", ", parameters));
        cmd.Connection = new SqlConnection(connStr);
        using(var da = new SqlDataAdapter(cmd))
        {
            // ...
        }
    }
