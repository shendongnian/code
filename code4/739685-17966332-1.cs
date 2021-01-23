        string lienBaseConnaissance = null;
        SqlDataReader _ReaderLines = RequeteExiste.ExecuteReader();
        if(_ReaderLines.Read())
        {
             if (_ReaderLines["ParStrP1"].ToString() != null)
                 lienBaseConnaissance = _ReaderLines["ParStrP1"].ToString();
        }
        cnx.Close();   
        return lienBaseConnaissance;
