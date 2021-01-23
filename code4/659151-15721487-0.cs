     protected override void OnPreInit(EventArgs e)
       {    
        if (!IsPostBack)
           {
           
           Page.Title = YourTextBox.Text;
           }
        
        }
