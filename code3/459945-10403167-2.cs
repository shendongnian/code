    var dict = JsonConvert.DeserializeObject<RootClass>(json);
    foreach (var obj in dict.names)
    {
        Console.WriteLine(obj.name);
    }
       
    public class RootClass
    {
        public MyName[] names { get; set; }
    }
    public class MyName
    {
        public string name { get; set; }
    }
