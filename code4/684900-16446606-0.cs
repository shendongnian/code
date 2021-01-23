    try
    {
       ...
       thisConnection.Open();
       ...
    }
    catch (SqlException ex)
    {
        for (int i = 0; i < ex.Errors.Count; i++)
        {
            Console.WriteLine(ex.Errors[i].ToString());
            // or output them wherever you need to see them
        }
    }
