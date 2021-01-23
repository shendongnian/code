    public /*static?*/ bool foo()
    {
        try
        {
            //do stuff
        }
        catch(ArgumentException)
        {
            return true
        }
        catch
        {
            return false
        }
        return false;
    }
