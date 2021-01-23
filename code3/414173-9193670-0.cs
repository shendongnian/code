    // to replace unwanted characters with space
    text = System.Text.RegularExpressions.Regex.Replace(text, "[(),.]", " ");
    // to replace multiple spaces with one
    text = System.Text.RegularExpressions.Regex.Replace(text, "\\s+", " ");
    
    // to split the text with SPACE delimiter
    var splitted = text.Split(' ');
