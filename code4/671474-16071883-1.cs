        try
        {
           //statements
        }
        catch (SoapException se)
        {
            //Log statement
            return null;
        }
        catch (Exception ex)
        {
            //Log statement
            try
            {
                 throw;
            }
            catch (Exception)
            {
                 //Handle first thrown exception.
            }
            throw;
        }
