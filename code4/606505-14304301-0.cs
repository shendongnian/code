            if ((e.KeyChar >= '0') && (e.KeyChar <= '9') && (txt1.Text.Length < 10))
            {
            }
            else if (e.KeyChar == 0x08)
            {
                //BACKSPACE CHAR
            }
            else if (txt1.SelectionLength > 0)
            {
                //IF TEXT SELECTED -> LET IT OVERRIDE
            }
            else
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
