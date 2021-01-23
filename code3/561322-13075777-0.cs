    static private void TryThisFunc(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
