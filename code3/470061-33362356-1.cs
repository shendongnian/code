    static void Main(string[] args)
    {
         string jsonText = System.IO.File.ReadAllText("MyJSONFile.txt");
         var rootObj = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(jsonText);
         rootObj.details.ForEach(detail =>
         {
             Console.WriteLine(detail.state);
             detail.place.ForEach(p =>
             {
                 if (string.IsNullOrWhiteSpace(p.name) == false)
                 {
                      Console.WriteLine(p.name);
                 }
                 if (string.IsNullOrWhiteSpace(p.name1) == false)
                 {
                      Console.WriteLine(p.name1);
                 }
                 if (string.IsNullOrWhiteSpace(p.name2) == false)
                 {
                      Console.WriteLine(p.name2);
                 }
                 if (p.age > 0)
                 {
                      Console.WriteLine(p.age);
                 }
                 Console.WriteLine(string.Empty);
             });
         });
         Console.ReadKey(true);
    }
