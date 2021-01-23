     else
                    {
                       
                        for (int i = 0; i < tabForms.TabCount; i++)
                            {
                                if (tabForms.TabPages[i].Text == this.ActiveMdiChild.Text.ToString())
                                    {
                                        tabForms.SelectedTab = tabForms.TabPages[i];
                                                break;
                                    }
                            }
                    }                  
                    if (!tabForms.Visible) tabForms.Visible = true;
