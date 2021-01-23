       bool blHasDot=false;
       private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                // Allow Digits and BackSpace char
            }
            else if (e.KeyChar == '.' && !blHasDot)
            {
                //Allows only one Dot Char
                blHasDot=true;
            }
            else
            {
                e.Handled = true;
            }
        }
