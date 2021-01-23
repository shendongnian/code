     public Button btnSubmit; // Add the on class level as data member
    Protected void Page_PreInit(object sender, EventArgs e)
    {
           btnSubmit = new Button();        
           btnSubmit.Text = "Click me";           
           btnSubmit.Click +=new EventHandler(btnSubmit_Click);
           this.form1.Controls.Add(btnSubmit); 
    }
