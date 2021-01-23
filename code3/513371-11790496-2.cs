     for (int i = 0; i < numberOfListBox ; i++)
            {
                ListBox listb = new ListBox();
                ListItem lItem = new ListItem();
                lItem.Value = i.ToString();
                lItem.Text = "item no" + i;
                listb.Items.Add(lItem);
                Panel1.Controls.Add(listb);
                    
            }
