    public void PrintProperties(object o, params string[] propertyNames)
    {
        foreach (var propertyName in propertyNames)
        {
            // Dont have VS now, but it's something like that
            Console.WriteLine(o.GetType().GetProperty(propertyName).GetValue(o, null));
        }
    }
