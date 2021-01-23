            var urn = new Urn("Server[@Name='MyServerName']/Database[@Name='MyDatabaseName']/Table[@Name='MyTableName' and @Schema='MySchemaName']");
            for (var i = 0; i < urn.XPathExpression.Length; i++)
            {
                Console.WriteLine("ItemName ({0})", urn.XPathExpression[i].Name);
                foreach (DictionaryEntry item in urn.XPathExpression[i].FixedProperties)
                {
                    Console.WriteLine("\tPropertyName ({0}), PropertyValue ({1})", item.Key, item.Value);
                }
            }
