    protected void Page_Load(object sender, EventArgs e)
    {
         if (!this.IsPostBack)
         {
             // in this method u will bind your GridView
             this.BindGrid();
         }
    }
