    private void Form_MouseMove(object sender, MouseEventArgs e)
    {
        // Update the mouse coordinates displayed in the textbox.
        myTextBox.Text = e.Location.ToString();
    }
