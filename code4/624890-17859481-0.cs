    public partial class multiACEfromCodeBehind : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {	
        	    for(int i = 0; i < 10; i++)
        	    {
                    // Create TextBox and its properties
                    string textBoxID = String.Format("{0}_{1}", "AutoCompleteTextBox", i);
                    TextBox textbox = new TextBox();
                    textbox.ID = textBoxID;
                    textbox.Width = new Unit(250);
                    textbox.Attributes.Add("autocomplete", "off");
                
                    // Create AutoCompleteExtender and its properties
                    AutoCompleteExtender autoCompleteExtender = new AjaxControlToolkit.AutoCompleteExtender();
                    autoCompleteExtender.TargetControlID = textBoxID;
                    autoCompleteExtender.ServiceMethod = "GetCompletionList";
                    autoCompleteExtender.ServicePath = "YourAutoCompleteWebService.asmx";
                    autoCompleteExtender.CompletionInterval = 1500;
                    autoCompleteExtender.CompletionSetCount = 10;
                    autoCompleteExtender.EnableCaching = true;
                
                    // Add created controls to the page controls collection
                    this.Controls.Add(textbox);
                    this.Controls.Add(autoCompleteExtender);
        	    }
            }
        }
    }
