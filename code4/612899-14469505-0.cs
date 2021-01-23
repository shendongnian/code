    DTE dte = (DTE).Package.GetGlobalService(typeof(DTE));
    if(dte.Debugger.CurrentStackFrame != null) // Ensure that debugger is running
    {
        EnvDTE.Expressions locals = dte.Debugger.CurrentStackFrame.Locals;
        foreach(EnvDTE.Expression local in locals)
        {
            EnvDTE.Expressions members = expression.DataMembers;
            // Do this section recursively, looking down in each expression for 
            // the next set of data members. This will build the tree.
            // DataMembers is never null, instead just iterating over a 0-length list.
        }
    }
