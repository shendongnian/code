    var applicationDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    if(!String.IsNullOrEmpty(applicationDirectory ))
    {
 
        var runtimeResourcesDirectory = Path.Combine(applicationDirectory , "RuntimeResources");
        var pc = new ParserContext
        {
            BaseUri = new Uri(runtimeResourcesDirectory , UriKind.Absolute)
        };
        if(Directory.Exists(runtimeResourcesDirectory ))
        {
            foreach (string resourceDictionaryFile in Directory.GetFiles(runtimeResourcesDirectory , "*.xaml"))
            {
                using (Stream s = File.Open(resourceDictionaryFile, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        var resourceDictionary = XamlReader.Load(s, pc) as ResourceDictionary;
                        if (resourceDictionary != null)
                        {
                            Resources.MergedDictionaries.Add(resourceDictionary);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid xaml: " + resourceDictionaryFile);
                    }
                }
            }
        }
    }
