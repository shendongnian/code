    private DataSet DatelineData(...)
    {
        using(var connection = new SqlConnection(settings))
        {
             SqlParameter colomNamePrm, startdatePrm, EnddatePrm, StartPrm, EndPrm;                                        
             connection.Open();
             using (var command = connection.CreateCommand())
             {
                 ....
                 return dateDs;
             }
        }
    }
