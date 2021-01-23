    using (var writer = File.CreateText("G:/user/data/yr2009/fy09_filtered.txt"))
    {
        for (int i = 1; i <= 15; i++)
        {
            string inputName = "G:/user/data/yr2009/fy09_filtered" + i + ".txt";
            writer.Write(File.ReadAllText(inputName));
        }
    }
