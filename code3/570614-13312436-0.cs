    int minsEntered = 0;
    int secsEntered = 0;
    
    if(!string.IsNullOrWhitespace(textMins.Text))
    {
      minsEntered = int.Parse(txtMins.Text);
    }
    
    if(!string.IsNullOrWhitespace(txtSecs.Text))
    {
      secsEntered = int.Parse(txtSecs.Text);
    }
