    const string LabelToFind = "goTo considered Harmful";
    using (var file = new StreamReader(DownloadedFile))
    {
    	string line;
    	while ((line = file.ReadLine()) != null)
        {
            if (line.Contains(keyVal) && line.Contains(LabelToFind))
            {
                var logLineElements = line.Split('|'); 
                foreach (var element in logLineElements)
                {
                    var index = element.IndexOf(LabelToFind, StringComparison.Ordinal);
                    if (index != -1)
                    {
                        return element.Substring(index + LabelToFind.Length, element.Length - LabelToFind.Length - index);
                    }
                }
            }
        }
    }
