    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (IsPostBack)
            {
                //If the form is posting the button, it means you clicked it
                bool isButtonPostBackEvent = Request.Form.AllKeys.Contains(Button1.UniqueID);
                
                string selectedValue = Request.Form[DropDownList1.UniqueID];
                int valueIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByValue(selectedValue));
                
                //Verify if posted value of the dropdownlist is different from the server (will raise the SelectedIndexChangedEvent event)
                bool willRaiseSelectedIndexChangedEvent = DropDownList1.SelectedIndex != valueIndex;
                //Verifies if both events will be fired, so apply the button
                //behavior, otherwise let the asp.net do its 
                //magic and raise the events automatically
                if (isButtonPostBackEvent && willRaiseSelectedIndexChangedEvent)
                {
                    RedirectToYahoo();
                }
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RedirectToGoogle();
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            RedirectToYahoo();
        }
        private void RedirectToGoogle()
        { 
            Response.Redirect("http://www.google.com");
        }
        private void RedirectToYahoo()
        { 
            Response.Redirect("http://www.yahoo.com");
        }
    }
