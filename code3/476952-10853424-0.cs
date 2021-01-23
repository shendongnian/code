    textBox.KeyDown += (sender, e) =>
                                   {
                                       if (!(
                                           //"+
                                           e.KeyCode == Keys.Add || 
                                           //numeric
                                           (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || 
                                           //space
                                           e.KeyCode == Keys.Space))
                                       {
                                           e.Handled = true;
                                       }
                                   };
    textBox.Validating += (sender, eventArgs) =>
                                      {
                                          var regex = new Regex(@"[^0-9\+ ]+");
                                          textBox.Text = regex.Replace(textBox.Text, string.Empty);
                                      };
