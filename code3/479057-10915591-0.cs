     string fileAContent = File.ReadAllText(fileAPath);
     string fileBContent = File.ReadAllText(fileBPath);
     string[] fileAWords = filesAContent.split(_your delimiters_);
     string[] fileBWords = filesBContent.split(_your delimiters_);
     if (fileAWords.Except(fileBWords).Length > 0)
     {
        // there are words in file B that are not in file A
     }
