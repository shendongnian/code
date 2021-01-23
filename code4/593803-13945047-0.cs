    Console.WriteLine(JsonConvert.DeserializeObject<Menu>(
        @"{
             ""name"":""bob"",
             ""next"":
             {
               ""$type"" : ""ConsoleApplication.NextStepCommand,ConsoleApplication"",
               ""step"" : 1
             }
        }",
        new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto }).Next);
