    public static T[] Shuffle<T>(IEnumerable<T> items)
    {
        var result = items.ToArray();
        var r = new Random();
	for (int i = items.Length; i > 1; i--)
	{
            int j = r.Next(i);
	    var t = result[j];
	    result[j] = result[i - 1];
	    result[i - 1] = t;
	}
        return result;
    }
    var myValues = new int[] { 1, 2, 3, 4, 5, 6 }; // Will work with any enumerable
    var randomValues = myValues.Shuffle().Take(3);
