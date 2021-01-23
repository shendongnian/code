    public void alert()
            {
                int i=0;
                foreach (ListItem listItem in cblCustomerList.Items)
                {
                    if (listItem.Selected)
                    {
                        i++;
                    }
                }
                if(i !=0)
                {
                    Response.Write("Please check at least one option");
                }
            }
        }
