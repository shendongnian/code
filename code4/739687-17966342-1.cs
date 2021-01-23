    public string LienBaseDeConnaissance(string entreprise)
    {
    	using(SqlConnection cnx = new SqlConnection("Data Source=SR8-ICARE-SQL;Initial Catalog=db_GENAPI_CM;User Id='IcareReader';Password='$Genapi.Reader1$';"))
    	{
    		...		
    		SqlDataReader _ReaderLines = RequeteExiste.ExecuteReader();
    		...
    	}
    	return null; 
    }
