    public static void GrowlMessage(System.Web.UI.Control pageControl, string header = "", string message = "", bool sticky = false, string position = "top-right", string theme = "", bool closer = true, int life = 8)
    {
        string _js = "$.jGrowl('" + HttpContext.Current.Server.HtmlEncode(message) + "', { header:'" + header + "', sticky:" + sticky.ToString().ToLower() + ", position: '" + position + "', theme: '" + theme + "', closer: " + closer.ToString().ToLower() + ", life:" + life * 1000 + "});";
        ScriptManager.RegisterStartupScript(pageControl, pageControl.GetType(),"Growl",_js, true);            
    }
