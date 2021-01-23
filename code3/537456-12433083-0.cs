    private void MyToggleButton_Click(object sender, EventArgs e) {
        // Set all Buttons in the Panel to their 'default' appearance.
        var panelButtons = panel.Controls.OfType<Button>();
        foreach (Button button in panelButtons) {
            button.BackColor = Color.Green;
            // Other changes...
        }
    
        // Now set the appearance of the Button that was clicked.
        var clickedButton = (Button)sender;
        clickedButton.BackColor = Color.Red;
        // Other changes...
    }
