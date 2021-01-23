      public void Main()
       {
         ArrayList arr = new ArrayList(); 
            
            Microsoft.SqlServer.Dts.Runtime.Application app = new Microsoft.SqlServer.Dts.Runtime.Application();
            Package pkg = app.LoadPackage(Your Package Location,null);
              
            Variables pkgVars = pkg.Variables;
            foreach (Variable pkgVar in pkgVars)
            {
                if (pkgVar.Namespace.ToString() == "User")
                {
                    arr.Add(string.Concat ( pkgVar.Name,',',pkgVar.Value ));
                }
            }
            Dts.Variables["User::VariableCollection"].Value = arr;
            // TODO: Add your code here
            Dts.TaskResult = (int)ScriptResults.Success;
        }
