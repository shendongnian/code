    public void createProjectItem(DTE2 dte)
    {
        //Adds a new Class to an existing Visual Basic project.
        Solution2 soln;
        Project prj;
        soln = (Solution2)_applicationObject.Solution;
        ProjectItem prjItem;
        String itemPath;
        // Point to the first project (the Visual Basic project).
        prj = soln.Projects.Item(1);
        // Retrieve the path to the class template.
        itemPath = soln.GetProjectItemTemplate("Class.zip", "vbproj");
        //Create a new project item based on the template, in this
        // case, a Class.
        prjItem = prj.ProjectItems.AddFromTemplate(itemPath, "MyNewClass");
    }
