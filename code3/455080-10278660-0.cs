    public void OnButtonClick(object sender, EventArgs e) {
        int value;
        bool isValid = int.TryParse(textBox.Text, out value);
        if (isValid) {
            // send to WCF
        }
        else {
            // display a message
        }
    }
