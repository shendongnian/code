    private void decimalTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            bool isGoodData;    // flag to make the flow clearer.
            TextBox theTextBox = (TextBox)sender;  // the sender is a textbox
          
            if (e.Key>= Windows.System.VirtualKey.Number0 && e.Key <= Windows.System.VirtualKey.Number9)  // allow digits
                isGoodData = true;
            else if (e.Key == Windows.System.VirtualKey.Tab)
                isGoodData = true; 
            else if (e.Key >= Windows.System.VirtualKey.NumberPad0 && e.Key <= Windows.System.VirtualKey.NumberPad9)  // allow digits
                isGoodData = true;
            else if (e.Key == Windows.System.VirtualKey.Decimal || (int)e.Key == 190)   // character is a decimal point, 190 is the keyboard period code
                                                                                        // which is not in the VirtualKey enumeration
            {
                if (theTextBox.Text.Contains("."))   // search for a current point
                    isGoodData = false;    // only 1 decimal point allowed
                else
                    isGoodData = true;     // this is the only one.
            }
            else if (e.Key == Windows.System.VirtualKey.Back)  // allow backspace
                isGoodData = true;
            else
                isGoodData = false;   // everything else is bad
            if (!isGoodData)          // mark bad data as handled
                e.Handled = true;
        }
