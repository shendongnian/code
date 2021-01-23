    Dictonary<string,bool> loadedAssemblies = new Dictonary<string,bool>();
    using(SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
    {
        var hash = Convert.ToBase64String(sha1.ComputeHash(byteArray));
        if(loadedAssemblies.ContainsKey(hash)) continue;
        loadedAssemblies[hash] = true;
        Assembly dll = Assembly.Load( File.ReadAllBytes(i));
        SomeInterface if = CreateInstance(dll); //This methods does all the validation and such
        if.DoMethod();
    }
