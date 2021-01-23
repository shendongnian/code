    private static bool hasTestCaseAttribute(MethodInfo method)
    {    
        object[] customAttributes = Attribute.GetCustomAttribute(method, 
                                        typeof(TestCase), true) as TestCase;
        if(customAttributes.Length>0 && customAttributes[0]!=null)
        {
            return true;
        }
        else
        {
            return false;
        }
      }
