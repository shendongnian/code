    string str = @"using system;
    using system.blab;
    using system.blab.blabity;";
    
    str = Regex.Replace(str, @"\b(using)\b", "<$1>");
