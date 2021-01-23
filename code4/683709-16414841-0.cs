    string ns = "System.Text";
    var types = from asm in AppDomain.CurrentDomain.GetAssemblies()
                from type in asm.GetTypes()
                where type.Namespace == ns
                orderby type.Name
                select type;
    foreach(var type in types)
    {
        Console.WriteLine("{0} ({1})", type.Name, type.Assembly.FullName);
        // and list the methods for each type...
        foreach (var method in type.GetMethods().OrderBy(x => x.Name))
        {
            Console.WriteLine("\t{0}", method.Name);
        }
    }
