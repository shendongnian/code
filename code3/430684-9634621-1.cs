    int numeOrdinal = reader.GetOrdinal("Nume");
    int intrebariOrdinal = reader.GetOrdinal("Intrebari");
    int i = 1;
    while (rdr.Read()) {
        // Nume (Romanian) = Name
        page.FindControl("lbl" + i).Text = reader.IsDBNull(numeOrdinal)
            ? ""
            :  rdr.GetString(numeOrdinal);
        // Intrebari (Romanian) = Question
        page.FindControl("intrebari" + i + 5).Text = reader.IsDBNull(intrebariOrdinal)
            ? ""
            : rdr.GetString(intrebariOrdinal);
        i++;
    }
