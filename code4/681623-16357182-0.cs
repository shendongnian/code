      foreach (Control c1 in c.Controls)
                    {
                        if (c1.GetType() == typeof(TextBox))
                        {
            if(flag==1)
            {
            ((TextBox)c1).Visible=True;
            }
    else
    {
     ((TextBox)c1).Visible=False;
    }
                            
            if(((TextBox)c1).Text != "")
            {
            flag=1;
            }
        else
        {
        flag=0;
        }
                        }
