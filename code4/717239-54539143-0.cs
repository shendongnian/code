    using EnvDTE;
    using EnvDTE80;
    
    public class C : VisualCommanderExt.ICommand
    {
    	public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
    	{
            EnvDTE.TextSelection ts = DTE.ActiveWindow.Selection as EnvDTE.TextSelection;
            if (ts == null)
                return;
    
            EnvDTE.CodeClass c = ts.ActivePoint.CodeElement[vsCMElement.vsCMElementClass]
                        as EnvDTE.CodeClass;
            if (c == null)
                return;
    
            foreach(EnvDTE.CodeElement e in c.Members)
            {
                if(e.Kind== vsCMElement.vsCMElementFunction)
                {
                    EnvDTE.TextPoint p = (e as EnvDTE.CodeFunction).GetStartPoint();
                    DTE.Debugger.Breakpoints.Add("", p.Parent.Parent.FullName, p.Line);
                }
            }
        }
    }
