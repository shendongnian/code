                        // Get the name which will be passed into the textbox
                        var resval = form2result.getValue();
                        // The user didn't select anything somehow.
                        if (resval == null)
                        {
                          MessageBox.Show("Nothing Selected"); 
                          return;
                        }
                        // resval hasn't been setup correctly.
                        if (resval.types == null)
                        {
                          MessageBox.Show("Internal Error"); 
                          return;
                        }
                        //go through each of my textbox
                        foreach (TextBox tb in TextBoxList)
                        {
                            var tbItems = (ReportItems)tb.Tag;
                            //The Textbox must contain text and tbItems must not be null
                            if (tb.Text != "" && tbItems != null)
                            {
                                //The tag has been set, but somehow the types are null?
                                if (tbItems.types == null)
                                {
                                    MessageBox.Show("Internal Error");    
                                break;
                                }
                                //if the item returned is the same as an item in the textbox
                                if (resval.types.xan_ID == tbItems.types.xan_ID)
                                {
                                    // display this message and break out of the loop
                                    MessageBox.Show("You have previously selected this report, please chose another");
                                    break;
                                }
                                    // otherwise add the item into the textbox.
                                else
                                {
                                    // otherwise add name to the textbox
                                    _dict[sender].Text = resval.ToString();
                                    //set the tag? 
                                    _dict[sender].Tag = tbItems;
                                }
                            }   
                        }
