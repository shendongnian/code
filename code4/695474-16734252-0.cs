    int number = 0;
    
    if (string.IsNullOrEmpty(this.BugCompPct.Text)
    {
        //not valid
    }
    else if (Int32.TryParse(this.BugCompPct.Text, out number))
    {
        if (number > 0 && number < 100)
        {
           //valid
        }
    }
