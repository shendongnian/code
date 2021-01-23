        private void numericComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                e.SuppressKeyPress = false;
                // Determine whether the keystroke is a number from the top of the keyboard.
                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                {
                    // Determine whether the keystroke is a number from the keypad.
                    if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    {
                        // Determine whether the keystroke is a backspace or arrow key
                        if ((e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Right) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Left))
                        {
                            // A non-numerical keystroke was pressed.
                            // Set the flag to true and evaluate in KeyPress event.
                            e.SuppressKeyPress = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Handle any exception here...
            }
        }
