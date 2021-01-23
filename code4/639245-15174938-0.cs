    public thing Outer()
    {
        try
        {
            return Inner();
        }
        catch
        {
            return null;
        }
    }
