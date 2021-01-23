    public partial class TextInputPage : System.Web.UI.Page, ITextView
    {
        ...
        
        public string SessionTextEntry 
        { 
            get { return (string)Session["TextInput"]; }
            set { Session["TextInput"] = value; }
        }
    
        public void RedirectToTestPage()
        {
            Response.Redirect("/SessionTestWebSite/ResultOutputPage.aspx");
        }
    
        ...
    }
