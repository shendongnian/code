    var list = new[] { 1, 2, 3, 4, 5, 11, 11, 12, 13, 3, 5, 6, 11, 22, 12, 24, 5, 6, 22, 33 };
    var cur = new List<int>();
    var result = new List<List<int>>();
    foreach (var ele in list)
    {
        if (ele > 10)
            cur.Add(ele); // Add to current sequence
        else
        {
            if (cur.Count > 3)
                result.Add(cur); // Current sequence is valid
            cur = new List<int>(); // Start new sequence
        }
    }
    if (cur.Count > 3)
        result.Add(cur); // Final sequence is valid
