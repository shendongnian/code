    try{
         String s = GetStringData();
    }catch(Exception ex)
    {
        if(ex.InnerException != null) ex = ex.InnerException;
        Console.WriteLine(ex.Message);
    }
