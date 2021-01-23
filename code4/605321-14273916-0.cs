      void Page_Load(Object sender, EventArgs e)
      {
        HtmlInputButton NewButtonControl = new HtmlInputButton("submit");
        NewButtonControl.ID = "NewButtonControl";
        NewButtonControl.Value = "Click Me";
    
        // Create an EventHandler delegate for the method you want to handle the event
        // and then add it to the list of methods called when the event is raised.
        NewButtonControl.ServerClick += new System.EventHandler(this.Button_Click);
    
        // Add the new HtmlInputButton control to the Controls collection of the
        // PlaceHolder control. 
        ControlContainer.Controls.Add(NewButtonControl);
      }
    
      void Button_Click(Object sender, EventArgs e)
      {
        // Display a simple message. 
        Message.InnerHtml = "Thank you for clicking the button.";
      }
