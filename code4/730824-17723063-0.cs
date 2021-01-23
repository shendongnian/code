    var ids = new List<string>();
    var nums = new List<string>();
    foreach (var s in input.Split(';'))
    {
        int val;
        if (!int.TryParse(s, out val)) { ids.Add(s); }
        else { nums.Add(s); }
    }
