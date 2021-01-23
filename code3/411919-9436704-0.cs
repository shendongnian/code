    string exeFilePath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
    string exeDirPath = Path.GetDirectoryName(exeFilePath);
    string targetFile = "subfolder\\dictionary.xaml";
    string path_to_xaml_dictionary = new Uri(Path.Combine(exeDirPath, targetFile)).LocalPath;
    string strXaml = File.ReadAllText(path_to_xaml_dictionary);                    
    ResourceDictionary resourceDictionary = (ResourceDictionary)XamlReader.Parse(strXaml);
    Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
