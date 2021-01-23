    using System.Collections.Generic;
    using System;
    using Newtonsoft.Json;
    namespace ConsoleApplication1
    {
       class Program
       {
              static void Main(string[] args)
              {
                  string json = "[{\"_34\":{ \"Id\":\"34\", \"Z\":[\"42b23718-bbb8-416e-9241-538ff54c28c9\",\"c25ef97a-89a5-4ed7-89c7-9c6a17c2413b\"], \"C\":[] } }]";
                  var result = JsonConvert.DeserializeObject<Dictionary<string, Result>[]>(json);
                  Console.WriteLine(result[0]["_34"].Z[1]);
               }
       }
       public class Result
       {
            public string Id { get; set; }
            public string[] Z { get; set; }
            public string[] C { get; set; }
       }
    }
