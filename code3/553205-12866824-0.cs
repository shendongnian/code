    private void nameTextBox1Validated(object sender, EventArgs e) {
        if(isNameValid()) {
            // clear error
            nameErrorProvider.SetError(nameTextBox1, String.Empty);
        }
        else {
            // set some helpful message
            nameErrorProvider.SetError(nameTextBox1, "Invalid value.");
        }
    }
    private bool isNameValid() {
        // The logic for determining if a value is correct
        return nameTextBox1.Text == "hello";
    }
