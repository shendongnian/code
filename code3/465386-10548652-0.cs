    var fonts = new[] { "Arial", "Calibri", "Times New Roman" };
    var input = new[] { "Calibri Bold", "Arial Bold Itali", "Times New Roman" };
    var result = input.Select(item => fonts.Single(font => item.StartsWith(font)));
    // result == { "Calibri", "Arial", "Times New Roman" }
                 
