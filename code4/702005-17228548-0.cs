    string pathToVdProject = null;
    try
    {
        Window solutionExplorer = mApplicationObject.Windows.Item(Constants.vsWindowKindSolutionExplorer);
        if (solutionExplorer != null)
        {
            UIHierarchy uiHierarchy = (UIHierarchy)solutionExplorer.Object;
            if (uiHierarchy != null)
            {
                object[] selectedItems = (object[])uiHierarchy.SelectedItems;
                foreach (UIHierarchyItem uiItem in selectedItems)
                {
                    // Valid project
                    if (uiItem.Object is EnvDTE.Project)
                    {
                        EnvDTE.Project project = uiItem.Object as EnvDTE.Project;
                        if (project.FullName.Contains(".vdproj") || project.UniqueName.Contains(".vdproj")
                            || (String.Compare(project.Kind, ProjectsGuids.guidVdSetupProject, true) == 0))                                    
                        {
                            // Valid Project has property FullName which is full path to .vdproj file
                            pathToVdProject = project.FullName;
                            break;
                        }
                    }
                    else if (uiItem.Object is ProjectItem)
                    {
                        // This never happens...
                    }
                    else
                    {
                        // This is a little tricky: Unmodeled Projects cannot be casted to EnvDTE.Project http://msdn.microsoft.com/en-us/library/hw7ek4f4%28v=vs.80%29.aspx 
                        Solution2 solution = (Solution2)mApplicationObject.Solution;
    
                        // So get all projects in solution (including unmodeled) and try to find a match by name
                        foreach (Project project in solution.Projects)
                        {
                            if (project.Kind == EnvDTE.Constants.vsProjectKindUnmodeled)
                            {
                                // Unmodeled project found (Normal projects are recognized in 'uiItem.Object is EnvDTE.Project'
                                if (project.Name.Contains(uiItem.Name))
                                {
                                    // This is 'Project' for selected item
                                    if (project.Name.Contains(".vdproj") || project.UniqueName.Contains(".vdproj"))
                                    {
                                        // Unmodeled projects does not offer property FullName and UniqueName does NOT contain full path to file!
                                        FileInfo fileInfo = new FileInfo(solution.FullName);
                                        
                                        // Create full path from solution (.sln) path and project relative path
                                        pathToVdProject = fileInfo.DirectoryName + "\\" + project.UniqueName;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
