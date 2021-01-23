    int[,] txtmap;
    int height = 0;
    int width = 0;
    string fileContents = string.Empty;
    try
    {
        using (StreamReader reader = new StreamReader("Content/map.txt"))
        {
            fileContents = reader.ReadToEnd().ToString();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    string[] parts = fileContents.Split(new string[] { "\r\n" }, StringSplitOptions.None);
    for (int i = 0; i < parts.Length; i++)
    {
        if (i == 0)
        {
            // set width
            width = Int16.Parse(parts[i]);
        }
        else if (i == 1)
        {
            // set height
            height = Int16.Parse(parts[i]);
            txtmap = new int[width, height];
        }
        if (i > 1)
        {
            // loop through tiles and assign them as needed
            string[] tiles = parts[i].Split(new string[] { "," }, StringSplitOptions.None);
            for (int j = 0; j < tiles.Length; j++)
            {
                txtmap[i - 2, j] = Int16.Parse(tiles[j]);
            }
        }
    }
