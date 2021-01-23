            txtNotes.HorizontalContentAlignment = HorizontalAlignment.Left;
            txtNotes.VerticalContentAlignment = VerticalAlignment.Top;
            txtNotes.TextWrapping = TextWrapping.NoWrap;
            txtNotes.AcceptsReturn = true;
            txtNotes.TextChanged += delegate (object o, TextChangedEventArgs args)
            {
                //args.Handled = true;
                TextBox thisText = (TextBox)args.Source;
                 if (!isBusyUpdating)
                {
                    isBusyUpdating = true;
                    string updatedText = "";
                    bool blnUpdate = false;
                    int curPos = thisText.CaretIndex;
                    foreach (string thisLine in thisText.Text.Split('\n'))
                    {
                        
                        if (thisLine.Length > 60)
                        {
                            blnUpdate = true;
                            updatedText = updatedText + 
                                thisLine.Substring(0, 60)
                                .Replace("\n", "") +
                                          "\n" + thisLine.Substring(60);
                            curPos++;
                        }
                        else
                        {
                            updatedText = updatedText + thisLine + "\n";
                        }
                    }
                    if (blnUpdate)
                    {
                        thisText.Text = updatedText;
                        thisText.CaretIndex = curPos-1;
                    }
                    isBusyUpdating = false;
                }
            };
