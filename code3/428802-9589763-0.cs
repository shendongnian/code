    while (ctecka.Read())
        {
            exJmeno = ctecka[0].ToString();
            exPrijmeni = ctecka[1].ToString();
            vlozSQL.Parameters.AddWithValue("@name", exJmeno);
             vlozSQL.Parameters.AddWithValue("@surname", exPrijmeni);
            Response.Write(exJmeno + " " + exPrijmeni + " ");
            pridano = vlozSQL.ExecuteNonQuery();
        }
