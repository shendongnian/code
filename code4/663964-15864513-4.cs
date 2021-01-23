    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        char c = e.KeyChar;
        if (c >= 48 && c <= 57)
        {
            // numeric value
            // do something
        }
        else if (c == 42)
        {
            // multiply (*)
            // do something
        }
        else if (c == 47)
        {
            // divide (/)
            // do something
        }
        else if (c == 13)
        {
            // enter key
            // do something
        }
        else
        {
            // discard
            e.Handled = true;
        }
    }
