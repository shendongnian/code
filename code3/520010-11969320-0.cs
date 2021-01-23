    using System.Linq;
    Dictionary<string, dynamic> A = ...;
    Dictionary<string, dynamic> B = ...;
    // naiive atempt:
    var lookup = 
        A.Keys.Concat(B.Keys)
            .ToDictionary(key => key, key => new dynamic[]{ A[key], B[key] } ));
