    private string Foo(string decrypted)
    {
        return decrypted.Substring(0);
    }
    Foo:
    IL_0000:  ldarg.1     
    IL_0001:  ldc.i4.0    
    IL_0002:  callvirt    System.String.Substring
    IL_0007:  ret        
    private string Foo(string decrypted)
    {
        string s = decrypted.Substring(0);
        return s;
    }
    Foo:
    IL_0000:  ldarg.1     
    IL_0001:  ldc.i4.0    
    IL_0002:  callvirt    System.String.Substring
    IL_0007:  stloc.0     // s
    IL_0008:  ldloc.0     // s
    IL_0009:  ret     
    private string Foo(string decrypted)
    {
        string s = decrypted.Substring(0);
    	string t = s;
        return t;
    }
    Foo:
    IL_0000:  ldarg.1     
    IL_0001:  ldc.i4.0    
    IL_0002:  callvirt    System.String.Substring
    IL_0007:  stloc.0     // s
    IL_0008:  ldloc.0     // s
    IL_0009:  stloc.1     // t
    IL_000A:  ldloc.1     // t
    IL_000B:  ret    
