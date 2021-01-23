           private void IterateControls(Control ctrl)
        {
            foreach (Control item in ctrl.Controls)
            {
                if (item is AjaxControlToolkit.TabPanel)
                {
                    TabPanel tp = item as TabPanel;
                    foreach (Control tpControls in tp.Controls)
                    {
                        IterateControls(tpControls);
                    }
                }
                else
                    if (item.Controls.Count > 1)
                    {
                        IterateControls(item);
                    }
                    else
                    {
                        if (item.GetType() == typeof(DropDownList))
                        {
                            DropDownList dl = item as DropDownList;
                           //do something  
                        }
                        else if (item.GetType() == typeof(TextBox))
                        {
                            
                            TextBox txt = item as TextBox;
                            if (txt.ID == "testControlID")
                            {
                                //IT WORKS!! 
                            }
                            //do something  
                        }
                    }
            }
        }
