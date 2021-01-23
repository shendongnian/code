    void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
              Int32 i; //create a integer variable
              for (i = 1; i <= 10; i++) // will generate 10 LinkButton
              {
                  LinkButton lb = new LinkButton(); //create instance of LinkButton
                  lb.Text = Convert.ToString(i) + ""; //LinkButton Text
                  lb.ID = Convert.ToString(i); // LinkButton ID’s
                  lb.CommandArgument = Convert.ToString(i); // LinkButton CommandArgument
                  lb.CommandName = Convert.ToString(i); // LinkButton CommanName
                  lb.OnClientClick+= new CommandEventHandler(lb_Command); //Create Handler for it.
                  PlaceHolder1.Controls.Add(lb); // Adding the LinkButton in PlaceHolder
            }
        }
    }
