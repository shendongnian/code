    protected void Page_Init(object sender, EventArgs e)
    {
    
          //MyControl is the Custom User Control with a code behind file
          MyControl myControl = (MyControl)Page.LoadControl("~/MyControl.ascx");
    
          //UserControlHolder is a place holder on the aspx page where I want to load the
          //user control to.
          UserControlHolder.Controls.Add(myControl);
    
    }
