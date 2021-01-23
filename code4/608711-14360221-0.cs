    while ((Line = sr.ReadLine()) != null)
    {
        if (Line.Contains(value))
        {
            var setting = Line.Split('=')[1];
            Console.WriteLine(setting);
            sr.Close();
            return setting;
        }
    }
