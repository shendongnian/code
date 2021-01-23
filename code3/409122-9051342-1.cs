    using (CustomMessageBox myMessageBox = new CustomMessageBox())
    {
        myMessageBox.Text = "Initial text"; // optionally set the initial value of the text box
        if (myMessageBox.ShowDialog(this) == DialogResult.OK)
        {
            someVariable = myMessageBox.Text;
        }
    }
