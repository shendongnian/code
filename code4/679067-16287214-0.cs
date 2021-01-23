        // one solution for filtering characters in a textbox.       
        // this is the PreviewKeyDown handler for a textbox named tbNumerical
        // Need to add logic for cancelling repeated decimal point and minus sign
        // or possible notation like 1.23e2 == 123
        private void tbNumerical_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Input.Key k = e.Key;
            
            // to see the key enums displayed, use a textbox or label
            // someTextBox.Text = k.ToString();
            // filter out control keys, not all are used, add more as needed
           bool controlKeyIsDown = Keyboard.IsKeyDown(Key.LeftShift);      
            if (!controlKeyIsDown &&
                Key.D0 <= k && k <= Key.D9 ||
                Key.NumPad0 <= k && k <= Key.NumPad9 ||
                k == Key.OemMinus || k == Key.Subtract ||
                k == Key.Decimal || k == Key.OemPeriod)   // or OemComma for european decimal point
                
            else
            {
                e.Handled = true;
                // just a little sound effect for wrong key pressed
                System.Media.SystemSound ss = System.Media.SystemSounds.Beep;
                ss.Play();
            }
        }
