    public string ScriptDatabase()
    {
          var sb = new StringBuilder();
    
          var server = new Server(@"ServerName");
          var databse = server.Databases["DatabaseName"];
    
          var scripter = new Scripter(server);
          scripter.Options.ScriptDrops = false;
          scripter.Options.WithDependencies = true;
          scripter.Options.IncludeHeaders = true;
          //And so on ....
                
    
          var smoObjects = new Urn[1];
          foreach (Table t in databse.Tables)
          {
              smoObjects[0] = t.Urn;
              if (t.IsSystemObject == false)
              {
                  StringCollection sc = scripter.Script(smoObjects);
                        
                  foreach (var st in sc)
                  {
                      sb.Append(st);
                  }
               }
           }
                return sb.ToString();
     }
