    static void Main(string[] args)
    {
        var objects = new MyObjects();
        var distinctIDs = (from myObj in new MyObjects()
                           from service in myObj.Services
                           select service.ID).Distinct();
        var notDistinctIDs = from myObj in new MyObjects()
                             from service in myObj.Services
                             select service.ID;
        foreach (var id in distinctIDs)
        {
            Console.WriteLine("Distinct ID: {0}", id);
        }
        Console.WriteLine("---");
        foreach (var id in notDistinctIDs)
        {
            Console.WriteLine("Not Distinct ID: {0}", id);
        }
    }
