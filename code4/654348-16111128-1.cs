    static void FormatFile(string file)
    {
        EnvDTE.Solution soln = System.Activator.CreateInstance(
            Type.GetTypeFromProgID("VisualStudio.Solution.10.0")) as EnvDTE.Solution;
    
        soln.DTE.ItemOperations.OpenFile(file);
    
        TextSelection selection = soln.DTE.ActiveDocument.Selection as TextSelection;
        selection.SelectAll();
        selection.SmartFormat();
    
        soln.DTE.ActiveDocument.Save();
    }
