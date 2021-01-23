    public static void Test()
    {
        string JSON = @"[
            {'name':'Scooby Doo', 'age':10},
            {'name':'Shaggy', 'age':18},
            {'name':'Daphne', 'age':19},
            {'name':'Fred', 'age':19},
            {'name':'Velma', 'age':20}
        ]".Replace('\'', '\"');
        Console.WriteLine("Using JavaScriptSerializer");
        JavaScriptSerializer jss = new JavaScriptSerializer();
        object[] o = jss.DeserializeObject(JSON) as object[];
        foreach (Dictionary<string, object> person in o)
        {
            Console.WriteLine("{0} - {1}", person["name"], person["age"]);
        }
        Console.WriteLine();
        Console.WriteLine("Using JSON.NET (Newtonsoft.Json) parser");
        JArray ja = JArray.Parse(JSON);
        foreach (var person in ja)
        {
            Console.WriteLine("{0} - {1}", person["name"].ToObject<string>(), person["age"].ToObject<int>());
        }
    }
