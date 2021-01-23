     public static class Extension {
          public static string GetFullPath( this YourNodeType node)
          {
               return (node.Parent == null) 
                 ? node.Name 
                 : Path.Combine( node.Parent.GetFullPath(), node.Name);
          }
     }
