    using System.Collections.Generic;
    ...
    Dictionary<int, int> dict = new Dictionary<int, int>();
    dict.Add(5, 4);
    dict.Add(7, 8);
    if (dict.ContainsKey(5))
    {
        // [5, int] exists
        int outval = dict[5];
        // outval now contains 4
    }
