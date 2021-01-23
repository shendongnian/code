        String folder = Application.StartupPath;
        String file = "users.txt";
        String str;
        var splitArray = new String[];
        var strings = new List<string>();
        int row = 0;
        StreamReader reader = new StreamReader(folder + file);
        while ((str = reader.ReadLine()) != null)
        {
            splitArray = str.Split('~');
            foreach (var str in splitArray)
            {
             strings.Add(str);
            }
        }
