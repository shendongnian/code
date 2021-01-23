    for (int i = _from; i <= _to; i++)
     {
        try
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (condition is true)
                {
                    throw new Exception("Condition is true.");
                }
            }
        } 
        catch(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }//x
    }
    //y
