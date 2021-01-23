    try
    {
        Microsoft.Office.Interop.Access.Application accessApp = new Microsoft.Office.Interop.Access.Application();
        accessApp.Visible = true;
    
        accessApp.OpenCurrentDatabase(filePath);
    
        // Get the active VBProject item
        VBProject project = accessApp.VBE.VBProjects.Item(1);
    
        VBComponent module = project.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule);
    
        module.CodeModule.AddFromString(script);
    }
    catch (Exception ex)
    {
        // Trust or the VBA Project Module has not been enabled.
    }
