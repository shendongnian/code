    static void GeneratePoco(Config config)
            {
                var template = config.Poco;
                template.Schema = config.DatabaseInfo;
    
                File.WriteAllText(template.SavePath, template.TransformText());
    
                Console.WriteLine("      - POCOs generated for " + config.DatabaseInfo.DatabaseName + " complete");
            }
