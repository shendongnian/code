    StringBuilder message = new StringBuilder();
    if (input == string.Empty) message.Append("Nothing to encrypt!\n");
    if (typeComboBox.Text == null) message.Append("Nothing selected!\n");
    // ... repeat as many times as desired ...
    if (message.Length > 0) {
        MessageBox.Show(message);
        return null;
    } else {
        // proceed with your code here
    }
