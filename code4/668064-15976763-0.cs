    Page_PreInit(Object sender, EventArgs e)
    {
        Button yourBtn = new Button();
        // Set your other properties
        yourBtn.Click += yourEventHandlerName;
        // Add the control to the controls collection of whatever container it belongs in
        yourContainer.Controls.Add(yourBtn);
    }
