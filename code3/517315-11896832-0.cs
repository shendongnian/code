                ListViewItem item = lvwMessages.SelectedItems[0];
                if(item.Font.Bold)
                
                    {
                        lvwMessages.SelectedItems[0].Font = new Font(lvwMessages.Font, FontStyle.Regular);
                    }
                
