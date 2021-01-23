    protected void Page_Load(object sender, EventArgs e)
    {
         if(!Page.IsPostBack)
         {
              div1.Visible = false; //content 1
              div2.visible = true;  //content 2
         }
    }
