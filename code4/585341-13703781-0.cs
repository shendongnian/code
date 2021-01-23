    public string json = "";
    
    public Form1()
    {
        InitializeComponent();
        DirectoryEntry parent = new DirectoryEntry("LDAP://" + dom);
        json = InfoNode(parent);
        System.IO.File.WriteAllText(@"json.txt", json);
    }
    
    public string InfoNode(DirectoryEntry node)
    {
        string[] arr = node.Name.Split('=');
        var result = string.Empty;
    
        if (arr[0].Equals("ou",StringComparison.InvariantCultureIgnoreCase))
        {
            result = "'{'label':'" + arr[1] + "','path':'" + node.Path + "'";
    
            if (node.Children.Cast<DirectoryEntry>().Any())
            {
                result += String.Format(", children:[{0}]",
                                        String.Join(",\n ",
                                                    node.Children.Cast<DirectoryEntry>()
                                                        .Select(InfoNode).Where(s=>!string.IsNullOrEmpty(s))
                                                        .ToArray()));
            }
            result += "}";
        }
        return result;
    }
