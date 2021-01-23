      public void Main()
       {
         ArrayList _coll = new ArrayList(); 
            
            Microsoft.SqlServer.Dts.Runtime.Application app = new Microsoft.SqlServer.Dts.Runtime.Application();
            Package pkg = app.LoadPackage(Your Package Location,null);
              
            Variables pkgVars = pkg.Variables;
            foreach (Variable pkgVar in pkgVars)
            {
                if (pkgVar.Namespace.ToString() == "User")
                {
                    _coll.Add(string.Concat ( pkgVar.Name,',',pkgVar.Value ));
                }
            }
            Dts.Variables["User::VariableCollection"].Value = _coll;
            // TODO: Add your code here
            Dts.TaskResult = (int)ScriptResults.Success;
        }
