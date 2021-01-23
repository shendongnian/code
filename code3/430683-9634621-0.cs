    int numeOrdinal = reader.GetOrdinal("Nume");
    int intrebariOrdinal = reader.GetOrdinal("Intrebari");
    int i = 1;
    while (rdr.Read()) {
        page.FindControl("lbl" + i).Text = reader.IsDBNull(numeOrdinal)
            ? ""
            :  rdr.GetString(numeOrdinal);
        page.FindControl("interbari" + i + 5).Text = reader.IsDBNull(intrebariOrdinal)
            ? ""
            : (string)rdr.GetInt(intrebariOrdinal);
        i++;
    }
