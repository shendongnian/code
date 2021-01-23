    foreach (var line in File.ReadAllLines("file").Where(line => line.StartsWith("Version")))
    {
        int value = 0;
        if (int.TryParse(line.Replace("Version=","").Trim(), out value))
        {
            // do somthing with value
        }
    }
          
