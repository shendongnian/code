        int TextBoxValue = 1000;
        var reader = new StreamReader(File.OpenRead(@"C:\Users\J\Desktop\New Text Document (4).txt"));
        var contents = reader.ReadToEnd().Split(new string[] {"\r\n"}, StringSplitOptions.None);
        var iValueExists = (from String sLine in contents
                            where sLine.Contains("1000")
                            select sLine).Count();
        if (iValueExists > 0)
        {
            TextBoxValue = int.Parse(contents.Last().Split(new string[] {","}, StringSplitOptions.None).First()) + 1;
        }
