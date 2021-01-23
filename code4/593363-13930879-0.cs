       protected override bool OnBubbleEvent(object sender, EventArgs e)
        {
       
            if (e is CommandEventArgs)
            {
                var args = (CommandEventArgs)e;
                //Could use args.CommandArgument here
                switch(args.CommandName)
                {
                      case "DataUpdated":
                         
                         gvMyGrid.DataSource = myData; 
                         gvMyGrid.DataBind();          
                         return true;                  //Handled the event LIKE A BOSS
                }
            }
            return false;                              //I didn't handle this event
        }
