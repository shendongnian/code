    internal static void LoadControl<T>(Page P, 
                                         string ControlName
                                         out T control)
        where T : System.Web.UI.Control
    {
        control = (T)P.LoadControl(
                       String.Format("~/{0}{1}.ascx",
                                        WebGlobals.cControlDir, 
                                        ControlName));
    }
