    var sb = new StringBuilder();
    var ints; // Your int[]
    // Initial step because of the delimiters.
    sb.Append(ints[ints.Length - 1].ToString());
    // Starting with 2nd last element all the way to the first one.
    for(var i = ints.Length - 2; i >= 0; i--)
    {
        sb.Append("|");
        sb.Append(ints[i].ToString());
    }
    var result = sb.ToString();
