    protected override void OnInit (EventArgs e)
    {
      Button myButton = new Button();
      myButton.Text = "Test";
      myButton.Click += new EventHandler(myButton_Click);
      myDiv.Controls.Add(myButton);
    
      base.OnInit(e);
    }
    
    protected override void OnPreRender(EventArgs e)
    {
      myButton.Visible = myConditional;
    
      base.OnPreRender(e);
    }
