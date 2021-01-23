    public void Test()
    {
        var ys = new[] { 1, 2, 3, 4, 5, 4, 3, 2, 1, 2, 3, 4, 5, 4, 3, 4, 5, 4 };
        var indices = GetMinIndices(ys);
    }
    
    public List<int> GetMinIndices(int[] ys)
    {
        var minIndices = new List<int>();
        for (var index = 1; index < ys.Length; index++)
        {
            var currentY = ys[index];
            var previousY = ys[index - 1];
            if (index < ys.Length - 1)
            {
                var neytY = ys[index + 1];
                if (previousY > currentY && neytY > currentY) // neighbors are greater
                    minIndices.Add(index); // add the index to the list
            }
            else // we're at the last index
            {
                if (previousY > currentY) // previous is greater
                    minIndices.Add(index);
            }
        }
        return minIndices;
    }
