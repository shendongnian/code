    protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (IsPostBack){
                if (Request.Form[Button1.UniqueID] != null)
                {
                    //Get the data from the server
                    randomGridView(Table1, 1);
                    randomGridView(Table2, 4);
                }
                //Just display the form here
            
            
            
            }
        }
    
