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
            if (condition)
                throw;
            throw;
        }
