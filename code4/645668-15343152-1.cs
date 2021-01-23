     StringBuilder emptyreplace = new StringBuilder(); 
    using(StreamReader sr = File.OpenText(path)){
        while ((stringToRemove = sr.ReadLine()) != null)
        {
            if (!stringToRemove.Contains("string1"))
            {
                if (!stringToRemove.Contains("string2"))
                {
                    //USE StringBuilder.Append, and NOT string concatenation
                    emptyreplace.AppendLine(stringToRemove + Environment.NewLine);
                }
            }
        }
       ...
    }
