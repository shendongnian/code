    private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox caller = sender as TextBox;
            int position = caller.SelectionStart;
            _PasswordBoxControlDown = e.Control;  // toggle if control is also down
            switch (e.KeyCode)
            {
                case Keys.Delete: //delete pressed
                    if (caller.SelectionLength > 0)  //more than 1 character selected
                    {
                        for (int i = caller.SelectionStart; i < caller.SelectionStart + caller.SelectionLength; i++)
                            _SecurePassword.RemoveAt(caller.SelectionStart);   //remove from secure password
                        caller.Text = caller.Text.Remove(caller.SelectionStart, caller.SelectionLength); //update textbox to reflect number of characters
                        KeyDownDidSomething(caller, e, position);
                    }
                    else if (caller.SelectionStart < caller.Text.Length) // nothing selected - but cursor is not at the end of textbox
                    {
                        _SecurePassword.RemoveAt(caller.SelectionStart);
                        caller.Text = caller.Text.Remove(caller.SelectionStart, 1);
                        KeyDownDidSomething(caller, e, position);
                    }
                    break;
                case Keys.Back: //backspace pressed
                    if (caller.SelectionLength > 0) //more than 1 character selected
                    {
                        for (int i = caller.SelectionStart; i < caller.SelectionStart + caller.SelectionLength; i++)
                            _SecurePassword.RemoveAt(caller.SelectionStart); //remove from secure password
                        caller.Text = caller.Text.Remove(caller.SelectionStart, caller.SelectionLength); //update textbox to reflect number of characters
                        KeyDownDidSomething(caller, e, position);
                    }
                    else if (caller.SelectionStart > 0) // nothing selected - but cursor is not at the beginning of textbox
                    {
                        _SecurePassword.RemoveAt(caller.SelectionStart - 1);
                        caller.Text = caller.Text.Remove(caller.SelectionStart - 1, 1);
                        position--;
                        KeyDownDidSomething(caller, e, position);
                    }
                    break;
            }
            
         }
            e.Handled = true; //tells the text box that the event has been handled, text box will not write character to text box.
            caller.SelectionLength = 0;
        }
        private void KeyDownDidSomething(TextBox caller, KeyEventArgs e, int position)
        {
            //use this to do whatever you need to do when you handle an event (if at all)
        }
