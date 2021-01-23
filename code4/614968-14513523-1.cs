    IEnumerable<OpenXmlElement> Convert(string testString) {
        IEnumerable<OpenXmlElement> tabOutput = ConvertString<TabChar>(testString, '\t');
        List<OpenXmlElement> finalOutput = new List<OpenXmlElement>();
        foreach(OpenXmlElement oxe in tabOutput){
            if (oxe is Text)
            {
                IEnumerable<OpenXmlElement> breakOutput = ConvertString<Break>(((Text)oxe).WrappedText, '\n');
                finalOutput.AddRange(breakOutput);
            }
            else
            {
                finalOutput.Add(oxe);
            }
        }
    }
    IEnumerable<OpenXmlElement> ConvertString<T>(string input, char pattern) 
    where T: OpenXmlElement, new() {
        List<OpenXmlElement> output = new List<OpenXmlElement>();
        string[] parts = input.Split( pattern);
        if (parts.Length > 1)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                string part = parts[i];
                if (!string.IsNullOrEmpty(part))
                {
                    output.Add(new Text(part));
                }
                if (i < (parts.Length - 1))
                {
                    output.Add(new T());
                }
            }
        }
        else
        {
            output.Add(new Text(input));
        }
        return output;
    }
