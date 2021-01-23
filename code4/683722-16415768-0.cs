    //Parallel.ForEach(files,Countnumberofwordsineachfile);
    var fileContent = files
            .AsParallel()
            .Select(f=> f + "=" + Countnumberofwordsineachfile(f));
    
    
    // make this an 'int' function, more reusable as well
    public int Countnumberofwordsineachfile(string filepath)
    { ...; return characterCount; }
