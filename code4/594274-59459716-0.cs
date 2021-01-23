    public static class Validator
    {
    public static bool IsNameString(TextBox tb, string name, KeyPressEventArgs e)
        {
            bool valid = true;
            /*  e.KeyChar contains the character that was pressed
             e.Handled is a boolean that indicates that handling is done            
            if a bad character is entered, set e.Handled to true
            */
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '-' &&
              e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                valid = false;
                MessageBox.Show(name+ " can only accept letters, space, - and .");
                tb.Focus();
            }
            return valid;
        }
    }
