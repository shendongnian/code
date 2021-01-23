        void Method1()
        {
            var tableVars = new Dictionary<string, dynamic>();
            dynamic sampleObject = new ExpandoObject();
            sampleObject.Name = "Count";
            sampleObject.Type = "Int32";
            sampleObject.Value = "4";
            sampleObject.Default = "0";
            tableVars.Add("Sample", sampleObject);
            Insert("TableName", tableVars, "Connection");
        }
        string Insert(string table, Dictionary<string, dynamic> tableVars, string connection)
        {
            foreach (var v in tableVars)
            {
                Console.Write("Name is: ");
                Console.WriteLine(v.Value.Name);
            }
            return "";
        }
