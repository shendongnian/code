    var item = projects.GetEnumerator();
    while (item.MoveNext())
    {
      var project = item.Current as Project;
      for(i=1;i<project.ProjectItems.Count;i++)
      {
         string itemType = project.ProjectItems.Item(i).Kind;
         if (itemType  == ProjectKinds.vsProjectKindSolutionFolder)
         {
             // Do whatever
         }
      }
    }
