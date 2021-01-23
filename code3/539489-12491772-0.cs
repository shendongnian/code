    System.Text.RegularExpressions.Regex imageFilenameRegex = new 
    System.Text.RegularExpressions.Regex(@"(.*?)\.(jpg|jpeg|png|gif)$", 
    System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                
                
    bool ismatch =imageFilenameRegex.IsMatch(imgFile.FileName)
