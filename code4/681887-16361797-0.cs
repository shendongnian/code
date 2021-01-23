    if (string.IsNullOrWhiteSpace(YourName.Text)) {
        SubmitButton.Enabled = false; // <<== No double-quotes around false
    } else {
        // Don't forget to re-enable the button
        SubmitButton.Enabled = true;
    }
