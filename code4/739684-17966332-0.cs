        string lienBaseConnaissance = null;
        SqlDataReader _ReaderLines = RequeteExiste.ExecuteReader();
        while (_ReaderLines.Read())
        {
             if (_ReaderLines["ParStrP1"].ToString() != null)
                 lienBaseConnaissance = _ReaderLines["ParStrP1"].ToString();
             // You exit unconditionally from the loop after the first read....
             break;
        }
        cnx.Close();   
        return lienBaseConnaissance;
