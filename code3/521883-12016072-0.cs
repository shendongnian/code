    using System;
    string[] arr = new string[] { "apple", "berry", "cherry" };
    string sep = "\",\"";
    string enclosure = "\"";
    string result = enclosure + String.Join(sep, arr) + enclosure;
