    public void Page_Load(object sender, EventArgs e)
    {
      LinkButton dynamicButton = new LinkButton();
      dynamicButton.ID = "linkDynamic123";
      // this id needs to be the same as it was when you 
      // first sent the page containing the dynamic link to the client
      dynamicButton.Click += DynamicButton_Click;
      dynamicButton.Visible = false;
      Controls.Add(dynamicButton);
    }
    public void DynamicButton_Click(object sender, EventArgs e)
    {
      // as you created the control during Page.Load, this event will be fired. 
      ((LinkButton)sender).Visible = true;
    }
