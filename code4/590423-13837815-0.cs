            List<string> d = new List<string>();
            using (
                StreamReader stream =
                    File.OpenText(
                        "C:\\path\\Sources.json")
                )
            {
                JObject sources = (JObject) JToken.ReadFrom(new JsonTextReader(stream));
                var a = sources["on"];
                var b = a["sources"];
                var c = b["prgs"];
                foreach (JObject item in c["prg"].ToList())
                {
                    d.Add(item.Value<string>("name"));
                }
             
            }
           
            //part below is just for testing
            foreach (var VARIABLE in d)
            {
                Console.WriteLine(VARIABLE);
            }
            Console.ReadLine();
   
