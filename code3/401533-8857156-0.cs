    MethodInfo getSyntax = typeof(UriParser).GetMethod("GetSyntax", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
    FieldInfo flagsField = typeof(UriParser).GetField("m_Flags", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    if (getSyntax != null && flagsField != null)
    {
       foreach (string scheme in new[] { "http", "https" })
       {
           UriParser parser = (UriParser)getSyntax.Invoke(null, new object[] { scheme });
           if (parser != null)
           {
               int flagsValue = (int)flagsField.GetValue(parser);
              
               //0x20000 is the SimpleUserSyntax attribute
               if ((flagsValue & 0x20000) != 0)
                  flagsField.SetValue(parser, flagsValue & ~0x20000);
           }
        }
    }
    
    
    Uri u = new Uri("http://host.com?arg1=val&arg=val2%3d");
    //At this point, the %3d remains as expected.
