    public string LienBaseDeConnaissance(string entreprise)
    {
    	SqlConnection cnx = new SqlConnection("Data Source=SR8-ICARE-SQL;Initial Catalog=db_GENAPI_CM;User Id='IcareReader';Password='$Genapi.Reader1$';");
    	...
    	
    	
    	SqlDataReader _ReaderLines = RequeteExiste.ExecuteReader();
    	while (_ReaderLines.Read())
    	{
    		if (_ReaderLines["ParStrP1"].ToString() != null)
    		{
    			lienBaseConnaissance = _ReaderLines["ParStrP1"].ToString();
    			return lienBaseConnaissance;
    		}
    		else
    		{
    			return null;
    		}
    	}
    
    	cnx.Close();  
    	return null; //this line here
    }
