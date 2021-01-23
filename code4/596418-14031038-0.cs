    private Control getFollowingControl(Control c, string key,out Control returnControl)
    {        
        if(c.hasChild)
        {
            foreach(Control item in c.controls)
            {
                getFollowingControl(item,key,out returnControl);
            }
        }
        else
        {
            if(c.Id==key)
            {
                returnControl=c;
                break;
            }
        }
    }
