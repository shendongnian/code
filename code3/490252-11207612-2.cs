        string[]  amzProductAsins = GetProductAsin();;
        List<string[]> chunks = new List<string[]>();
        for (int i = 0; i < amzProductAsins.Count; i += 100)
        {
            chunks.Add(amzProductAsins.Skip(i).Take(100).ToArray());
        }
