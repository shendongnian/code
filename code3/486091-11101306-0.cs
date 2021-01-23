    class XElementFactory {
          public static XElement CreateXElement(string name, object value) {
              var type = obj.GetType();
              if (typeof(boolean).Equals(type))
                 // Format the XText accordig to specification, use the XText ctor for clarification and readability
                 return new XElement(name, (bool) obj ? new XText("True") : XText("False")); 
              // Maybe add additional if clauses if there are just a few special cases
              return new XElement(name, obj); // Let it through
          }
    }
