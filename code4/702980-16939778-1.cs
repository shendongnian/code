    static void Throws<T>(Action action) where T : Exception
    {
        try
        {
            action();
        }
        catch (T) { Console.WriteLine("got {0}", typeof(T)); }
        catch (Exception) { Console.WriteLine("got Exception"); }
    }
