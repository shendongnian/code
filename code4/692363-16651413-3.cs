    CodeTypeDeclaration type = new CodeTypeDeclaration("BugTracker");
    type.IsEnum = true;
    
    foreach (var valueName in new string[] { "Bugzilla", "Redmine" })
    {
      // Creates the enum member
      CodeMemberField f = new CodeMemberField("BugTracker", valueName);
      
    
      type.Members.Add(f);
    }
