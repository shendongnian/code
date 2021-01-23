    strSQLQuery = "select * from MyTable where IDData IN(" + String.Join(", ", ids.Select((s, i) => "@ID" + i)) + ")";
    foreach(var parameter in ids.Select((s, i) => new SqlParameter("@ID" + i, s)))
    {
        lstParametros.Add(parameter);
    }
