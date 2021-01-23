    static void Main()
    {
        //Anonymous Type
        var anyType = new
        {
            IntID = 1,
            StringName = "Wriju"
        };
     
        Type t = anyType.GetType();
        PropertyInfo[] pi = t.GetProperties();
        foreach (PropertyInfo p in pi)
        {
            //Get the name of the prperty
            Console.WriteLine(p.Name);
        }
    
        //Using LINQ get all the details of Property
        var query = from p in t.GetProperties()
                    select p;
        ObjectDumper.Write(query);
    }
