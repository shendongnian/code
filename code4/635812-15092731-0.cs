    public static bool IsUIElementHidden(System.Web.UI.HtmlControls.HtmlControl myControl)
            {            
                if ((myControl.Style["display"] ?? "").ToLower().Equals("none") || (myControl.Style["visibility"] ?? "").ToLower().Equals("none"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
