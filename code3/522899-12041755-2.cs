        // First get the list of filenames. I am using a string array for simplicity to denote input data.
        // I believe you are getting a collection from Directory.GetFiles
        string[] fileNames = { "abcd9876543211234567892", "abcd6662325999292112450"};
        string pattern = @"^abcd\d{19}$";
        foreach (string fileName in fileNames)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(fileName, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                //Do your upload
            }
            else
            {
                //Ignore or Record that this file is not eligible for upload or whatever...
            }
        }
