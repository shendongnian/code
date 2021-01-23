    internal static System.Web.UI.Control LoadControl(this Page P, string ControlName)
    {
        return P.LoadControl(String.Format("~/{0}{1}.ascx", WebGlobals.cControlDir, 
                                                            ControlName));
    }
