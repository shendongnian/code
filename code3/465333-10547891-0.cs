    public void makePanel()
    {
      /* ... */
      infoBtn.UseVisualStyleBackColor = true;
      infoBtn.Click += new EventHandler(ButtonClick);
      infoBtn.CommandArgument = "xxxxxxx"; // optional
    }
    
    public void ButtonClick(object sender, EventArgs e)
    {
      Button button = (Button)sender;
      string argument = button.CommandArgument; // optional
    }
