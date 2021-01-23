    if (CodeDomProvider.IsDefinedLanguage(language))
    {
        CodeDomProvider provider = CodeDomProvider.CreateProvider(language);
        // ...
    }
    else
        Console.WriteLine("ERROR");
