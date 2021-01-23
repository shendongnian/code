    public static List<List<Rectangle>> SortOverlap(Rectangle[] rectangles)
    {
        var result = new List<List<Rectangle>>();
        for (int i = 0; i < rectangles.Length; i++) 
        {
            var newList = new List<Rectangle>();
            newList.Add(rectangles[i]);
            for (int j = 0; j < result.Count; j++) 
            {
                if(result[j].Any(r => r.Overlap(newList[0])))
                {
                    newList.AddRange(result[j]);
                    result[j] = null;
                }
            }
            result.Add(newList);
            result.RemoveAll(list => list == null);
        }
        return result;
    }
