    catch (Exception e)
    {
        var t = e.GetType();
        while (t != null)
        {
            Console.WriteLine(t.AssemblyQualifiedName);
            t = t.BaseType;
        }
    }
