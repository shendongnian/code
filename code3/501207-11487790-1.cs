    static void Main()
    {
        // PNG file signature
        var startPattern = new byte[] { 137, 80, 78, 71, 13, 10, 26, 105 };
        var data = File.ReadAllBytes("png file");
        var start = data.Locate(startPattern);
        // and end like this
    }    
    public static int[] Locate(this byte[] self, byte[] candidate)
    {
        if (IsEmptyLocate(self, candidate))
            return Empty;
        var list = new List<int>();
        for (int i = 0; i < self.Length; i++)
        {
            if (!IsMatch(self, i, candidate))
                continue;
            list.Add(i);
        }
        return list.Count == 0 ? Empty : list.ToArray();
    }
    static bool IsMatch(byte[] array, int position, byte[] candidate)
    {
        if (candidate.Length > (array.Length - position))
            return false;
        for (int i = 0; i < candidate.Length; i++)
            if (array[position + i] != candidate[i])
                return false;
        return true;
    }
    static readonly int[] Empty = new int[0];
    static bool IsEmptyLocate(byte[] array, byte[] candidate)
    {
        return array == null
                || candidate == null
                || array.Length == 0
                || candidate.Length == 0
                || candidate.Length > array.Length;
    }
