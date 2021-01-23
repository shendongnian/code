            var x = new ExpandoObject() as IDictionary<string, Object>;
            string fm = "Training, Individual";
           
            var names = from info in XMLFile.Elements("PROJECTS").Elements("row")
                        where info.Element("FUNDING_MECHANISM").Value == fm
                        select info;
             x = GetExpandoForNodes(names.Descendants());
             foreach (string key in x.Keys)
             {
                 Console.WriteLine("Key: {0}, Value: {1}", key, x[key]);
             }
             Console.ReadKey();
