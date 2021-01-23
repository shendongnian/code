    while (ctecka.Read())
    {
        exJmeno = ctecka[0].ToString();
        exPrijmeni = ctecka[1].ToString();
        Response.Write(exJmeno + " " + exPrijmeni + " ");
        vlozSQL.Parameters.Clear();
        vlozSQL.Parameters.AddWithValue("@name", exJmeno);
        vlozSQL.Parameters.AddWithValue("@surname", exPrijmeni);
        pridano = vlozSQL.ExecuteNonQuery();
    }
