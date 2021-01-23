        int status = 1;
        foreach (ListItem  s in chklstStates.Items  )
        {
            if (s.Selected == true)
            {
                if (ListBox1.Items.Count == 0)
                {
                    ListBox1.Items.Add(s.Text);
                }
                else
                {
                    foreach (ListItem list in ListBox1.Items)
                    {
                        if (list.Text == s.Text)
                        {
                            status = status * 0;
                            
                        }
                        else
                        {
                            status = status * 1;
                        }
                    }
                    if (status == 0)
                    { }
                   else
                    {
                        ListBox1.Items.Add(s.Text);
                    }
                    status = 1;
                }
            }
        }
    }
