	var dict = new Dictionary<string, int> { { "b", 3 }, { "a", 4 } };
    // greatest key
	var maxKey = dict.Keys.Max(); // "b"
    
    // greatest value
	var maxValue = dict.Values.Max(); // 4
    // key of the greatest value
    // 4 is the greatest value, and its key is "a", so "a" is the answer.
	var keyOfMaxValue = dict.Keys.Aggregate((x, y) => dict[x] > dict[y] ? x : y); // "a"
