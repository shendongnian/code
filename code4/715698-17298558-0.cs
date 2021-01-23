     private void MyMethod()
     {
        try
        {
            {
                throw new Exception("Bleh");//<--- This's not caught => now it is caught :)
            }
        }
        catch (Exception ex)
        {
            Logger.Log(ex.ToString());
        }
    }
