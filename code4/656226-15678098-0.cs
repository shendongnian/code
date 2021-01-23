    protected void Page_Load(object sender , EventArgs)
    {
       ImageButton appIcon2 = new ImageButton();
       appIcon2.Click += new System.Web.UI.ImageClickEventHandler(btn_Click);
    }
   
    void btn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
       //your logic
    }
    
