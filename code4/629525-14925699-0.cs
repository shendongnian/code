    using System.Collections.Generic;
    Dictionary<int, type> dict = new Dictionary<int, type>();
    // Add values:
    dict.Add(2, A);
    dict.Add(4, B);
    dict.Add(7, C);
    // by index:
    var A = dict[2];
    var B = dict[4];
    var C = dict[7];
    // by place:
    var A = dict.ElementAt(0);
    var B = dict.ElementAt(1);
    var C = dict.ElementAt(2);
