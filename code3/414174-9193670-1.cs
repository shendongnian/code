    var text = "this (is a) text. and";
        
    // to replace unwanted characters with space
    text = System.Text.RegularExpressions.Regex.Replace(text, "[(),.]", " ");
        
    // to split the text with SPACE delimiter
    var splitted = text.Split(null as char[], StringSplitOptions.RemoveEmptyEntries); 
         
    foreach (var token in splitted) 
    {           
        Console.WriteLine(token);
    }
