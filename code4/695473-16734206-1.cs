    if (!string.IsNullOrWhiteSpace(BugCompPct.Text))
    {
        int temp; 
        if(int.TryParse(BugCompPct.Text,out temp)
        {
            if(temp >= 0 && temp <= 100)
            {
                //valid number (int)
            }
            else
            {
                //invalid number (int)
            }
        }
        else
        {
            //Entered text is not a number (int)
        }
    }
    else
    {
        //string is empty
    }
