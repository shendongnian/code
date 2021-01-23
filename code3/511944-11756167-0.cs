    string splitter = textbox1.Text.ToString().Substring(1);
    
    try {
        int number = Convert.ToInt32(splitter) + 1;
    } catch (FormatException e) {
        // Not a number...
    }
    textbox1.Text = String.Format("J{0}", number.ToString());
