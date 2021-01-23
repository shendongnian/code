            var list = new List<string> {"a", "b", "c", "d"};
            using(var output = Console.OpenStandardOutput())                
            {                
                var writer = new DataContractJsonSerializer(typeof (List<string>));
                writer.WriteObject(output,list);
            }
