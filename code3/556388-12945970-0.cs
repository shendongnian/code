    Assembly asm = Assembly.GetEntryAssembly();
    string cb = asm.CodeBase;
    var codeBase = new Uri(cb); 
    if (codeBase.IsFile) 
        return codeBase.LocalPath + Uri.UnescapeDataString(codeBase.Fragment);
    else
        return codeBase.ToString();
