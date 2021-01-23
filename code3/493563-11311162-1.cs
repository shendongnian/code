     // Check if anything needs a'doin'
     if(IsDirty(_git.Status().Call()))
     {
        // Add all new files to the commit.
         _git.Add().AddFilepattern(".").Call();
    
         // execute the commit, but don't push yet.
         _git.Commit().SetMessage(CommitMsg).SetAll(true).Call();
      }
