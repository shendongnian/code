    var t1 = typeof(int?);
    string s1 = t1.ToString();  // "System.Nullable`1[System.Int32]"
    bool b1 = Nullable.GetUnderlyingType(t1) != null;  // true
    var t2 = t1.MakeByRefType();
    string s2 = t2.ToString();  // "System.Nullable`1[System.Int32]&"
    bool b2 = Nullable.GetUnderlyingType(t2) != null;  // false
    // remove the ByRef wrapping
    var t3 = t2.GetElementType();
    string s3 = t3.ToString();  // "System.Nullable`1[System.Int32]" 
    bool b3 = Nullable.GetUnderlyingType(t3) != null;  // true
