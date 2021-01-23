    //Check to see if the first character is a space
            if (UsernameTextBox.SelectionStart == 0) //This is the first character
            {
                //Now check to see if the key pressed is a space
                if (e.KeyValue == 32)
                {
                    //Stop the key registering
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
