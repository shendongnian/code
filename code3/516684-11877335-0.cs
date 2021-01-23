    using System;
      namespace ConsoleApplication
      {
         [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    
    or
    
    <System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Assert, Unrestricted:=True)> _
    
       class Program
          {
              static void Main(string[] args)
              {
                   ...
              }  
          }
      }
