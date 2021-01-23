    using System;
    using System.Web.UI;
    
    namespace WebApplication1
    {
        public static class Extensions
        {
            public static void ShowAlert(this Control control, string message)
            {
                if (!control.Page.ClientScript.IsClientScriptBlockRegistered("msgbox"))
                {
                    var script = String.Format("alert('{0}');", message);
                    ScriptManager.RegisterClientScriptBlock(control.Page, control.Page.GetType(), "msgbox", script, true);
                }
            }
        }
    }
