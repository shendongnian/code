        string input = @"Server[@Name='MyServerName']/Database[@Name='MyDatabaseName']/Table[@Name='MyTableName' and @Schema='MySchemaName']";
        string elementPattern = @"(?<ItemName>\w+)\[@(?<PropertyName>\w+)='(?<PropertyValue>\w+)'( and @(?<PropertyName>\w+)='(?<PropertyValue>\w+)')*\]";
        Regex elementRegex = new Regex(elementPattern, RegexOptions.Compiled);
        string[] elements = input.Split('/');
        foreach (string element in elements)
        {
            Match m = elementRegex.Match(element);
            if (m.Success)
            {
                Console.WriteLine("ItemName ({0})", m.Groups["ItemName"]);
                foreach (Capture capture in m.Groups["PropertyName"].Captures)
                {
                    Console.WriteLine("PropertyName ({0})", capture.Value);
                }
                foreach (Capture capture in m.Groups["PropertyValue"].Captures)
                {
                    Console.WriteLine("PropertyValue ({0})", capture.Value);
                }
            }
        }
        Console.ReadKey();
