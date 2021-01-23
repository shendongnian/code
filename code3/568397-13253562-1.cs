    if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '') //The  character represents a backspace
    {
        e.Handled = false; //Do not reject the input
    }
    else
    {
        if (e.KeyChar == ')' && !txtHomePhone.Text.Contains(")"))
        {
            e.Handled = false; //Do not reject the input
        }
        else if (e.KeyChar == '(' && !txtHomePhone.Text.Contains("("))
        {
            e.Handled = false; //Do not reject the input
        }
        else if (e.KeyChar == '-' && !textBox1.Text.Contains("-"))
        {
            e.Handled = false; //Do not reject the input
        }
        else if (e.KeyChar == ' ' && !txtHomePhone.Text.Contains(" "))
        {
            e.Handled = false; //Do not reject the input
        }
        else
        {
            e.Handled = true;
        }
    }
