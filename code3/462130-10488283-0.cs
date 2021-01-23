    DTE2 dte2 = (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.10.0");
    Solution2 soln = (Solution2)dte2.Solution;
    
    string templateFileLoc = soln.GetProjectTemplate("My Pre-defined project template", "csproj");
    
    soln.AddFromTemplate(templateFileLoc, outputDir, projectName, false);
    
    var proj = soln.Projects.Item(soln.Projects.Count);
                
    proj.ProjectItems.AddFromFileCopy(generatedFile);
