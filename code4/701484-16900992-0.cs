        protected void Page_Load(object sender, EventArgs e)
        {
            //find if this is the initial get request
            //after you click a button, this code will not run again
            if (!IsPostBack)
            {
                //if (ViewState["clicks"] == null)
                //{
                //    ViewState["clicks"] = 0;
                //}
                //we're using the ViewState[clicks] to initialize the text in the text box
                TextBox1.Text = ViewState["clicks"].ToString();
            }
        }
