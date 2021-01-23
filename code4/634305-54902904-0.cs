     // in project 1
     namespace Tools {
          public static class NetworkTool {
          }
     }
     // in project 2
     namespace Tools {
          public static class FileTool {
          }
     }
     // in client code (references both projects)
     Tools.NetworkTool.SomeMethod();
     Tools.FileTool.SomeMethod()
      
