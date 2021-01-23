    int[] ConvertToIntArray(string a)
    {
        List<int> x = new List<int>();
        for(int i=0; i<a.Length-1; i+=2)
            x.Add(int.Parse(a.Substring(i, 2), System.Globalization.NumberStyles.HexNumber));
  
        return x.ToArray();
    }
