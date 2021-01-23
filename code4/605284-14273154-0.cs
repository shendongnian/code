    string child = "IS_PARENT, IS_CHILD_WITH_ROLE, IS_CHILD", 
           resultString = string.Empty;
    List<string> chunks = child.Split(' ').ToList();
    chunks.ForEach(delegate(string i)
    {
       if (string.Equals(i, "IS_CHILD", StringComparison.CurrentCultureIgnoreCase))
          resultString += "ReplaceString ";
       else
          resultString += i + " ";
    });
    Console.WriteLine(child);
    Console.WriteLine(resultString);
    
    Console.Read();
