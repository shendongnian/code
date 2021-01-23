    var message = 
        ((input==string.Empty ? 
            "Nothing to encrypt! " : 
            "") +
        (typeComboBox.Text == null ?
            "Nothing Selected!" :
            "")).Trim();
    if (message != "") {
        MessageBox.Show(message);
        return null;
    }
