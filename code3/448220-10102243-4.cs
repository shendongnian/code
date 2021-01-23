    internal static MyControl LoadControl(this Page P, string ControlName)
    {
        return (MyControl)P.LoadControl(String.Format("~/{0}{1}.ascx", 
                                        WebGlobals.cControlDir, 
                                        ControlName));
    }
