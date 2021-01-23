        string[]  amzProductAsins = GetProductAsin();;
        List<string[]> chunks = new List<string[]>();
        for (int i = 0; i < 1200; i += 100)
        {
            chunks.Add(amzProductAsins.Skip(i).Take(100).ToArray());
        }
