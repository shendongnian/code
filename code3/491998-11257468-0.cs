    ResourceReader res = new ResourceReader(@".\ApplicationResources.resources");
    IDictionaryEnumerator dict = res.GetEnumerator();
    while (dict.MoveNext())
       Console.WriteLine("   {0}: '{1}' (Type {2})", 
                         dict.Key, dict.Value, dict.Value.GetType().Name);
    res.Close();
