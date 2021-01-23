        String folder = Application.StartupPath;
        String file = "users.txt";
        String str;
        var strings = new List<string>();
        int row = 0;
        using (var reader = new StreamReader(Path.Combine(folder,file))
        {
        while ((str = reader.ReadLine()) != null)
        {
            var splitArray = str.Split('~');
            foreach (var str in splitArray)
            {
             strings.Add(str);
            }
        }
        }
