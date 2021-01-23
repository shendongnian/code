    void AnyButton_Click(Object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender; // unbox the sender
        MessageBox.Show("You just clicked button " clickedButton.Text);
    }
