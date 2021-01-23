            // db first
            using (var db = new SO15312066Entities())
            {
                // iterate over table 1, with join values from 2
                var query = db.Table1.Include("Table2");
                foreach (var item in query)
                {
                    Console.WriteLine("{0}:{1}", item.Id, string.Join(";", item.Table2.Select(x => x.Name).ToList()));
                }
            }
            //output
            //1:SomeText1;SomeText2
            //2:SomeText3
