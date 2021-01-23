               if (messagelist.Items.Count > 0)
                {
                    for (int i = 0; i < messagelist.Items.Count; i++)
                    {
                        string mnum = messagelist.Items[i].Text;
                        for (int j = 0; j < contactlist.Items.Count; j++)
                        {
                            if (contactlist.Items[j].SubItems[1].Text == mnum)
                            {
                                messagelist.Items[i].Text = contactlist.Items[j].Text;
                            }
                        }
                    }
                }
            
