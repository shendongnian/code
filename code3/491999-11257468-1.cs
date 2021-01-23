    var assem = Assembly.GetExecutingAssembly();
    var fs = assem.GetManifestResourceStream("res.resources");
    var rr = new ResourceReader(fs);`
    IDictionaryEnumerator dict = rr.GetEnumerator();    
    while (dict.MoveNext())
       Console.WriteLine("   {0}: '{1}' (Type {2})", 
                         dict.Key, dict.Value, dict.Value.GetType().Name);
    rr.Close();
