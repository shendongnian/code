    // 2. Start with a blank string
    var new_string = "";
    // 1. Replace first Length - n characters with X
    for (var i = 0; i < str.Length - n; i++)
        new_string += "X";
    // 3. Add in the last n characters from original string.
    new_string += str.Substring(str.Length - n);
