    if (!string.IsNullOrWhiteSpace(BugCompPct.Text))
    {
        int temp; 
        if(int.TryParse(BugCompPct.Text,out temp)
        {
            if(temp >= 0 && temp <= 100)
            {
                //valid number
            }
            else
            {
                //invalid number
            }
        }
        else
        {
            //Entered text is not a number
        }
    }
    else
    {
        //string is empty
    }
