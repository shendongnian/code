    using System;
    using System.Reflection;
    private string assemblyFullPath = "";
    public class myAssembly
    {
    static void Main()
    {
    Assembly assembly = Assembly.Load("library, version=1.0.0.0, culture=neutral, PublicKeyToken=9b184fc90fb9648d");
    assemblyFullPath = assembly.Location;
    
    } 
    } 
