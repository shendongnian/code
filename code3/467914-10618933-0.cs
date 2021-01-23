    if(line.Contains(line_to_delete)){
        var @index = line.IndexOf(line_to_delete);
        var commentSubstring = line.Substring(@index, line.Length - index); //Contains only the comments
        line.Replace(commentSubstring, "").ToString()//Contains the original with no comments
    }
