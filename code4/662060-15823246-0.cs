    List<List<List<List<GameObject>>>> Grid;
    Grid = Enumerable.Range(0, Layers).Select(l =>
           Enumerable.Range(0, Height).Select(h =>
           Enumerable.Range(0, Width).Select(w => 
               new List<GameObject>()).ToList()).ToList()).ToList();
