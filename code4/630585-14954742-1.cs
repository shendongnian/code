    static void Main(string[] args)
    {
        var test = new Test();
        var results = test.GetAllTasks(new[] { "Id"});
        foreach (var result in results)
        {
            Console.WriteLine((result as dynamic).Id);
        }
        results = test.GetAllTasks(new[] { "Name", "Description" });
        foreach (var result in results)
        {
            var dynamicResult=result as dynamic;
            Console.WriteLine("{0} {1}", dynamicResult.Name, dynamicResult.Description);
            // The following line will throw an exception
            //Console.WriteLine((result as dynamic).Id);
        }
    }
