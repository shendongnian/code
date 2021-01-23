     protected void Page_Load(object sender, EventArgs e)
        {
           if(!Page.IsPostBack)
            {
               textbox.text = "sometext";
            }
        }
        void Btn_Click(Object sender,EventArgs e)
        {
            String textbox_text = textbox.text;
            writeToDB(textbox_text);
        }
