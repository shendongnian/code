    List<List<List<List<GameObject>>>> Grid = new List<List<List<List<GameObject>>>>();
    for(var l = 0; l < Layers; l++)
    {
        Grid.Add(new List<List<List<GameObject>>>());
        for(var x = 0; x < Width; x++)
        {
            Grid[l].Add(new List<List<GameObject>>());
            for(var y = 0; y < Height; y++)
            {
                Grid[l][x].Add(new List<GameObject>());
            }
        }
    }
