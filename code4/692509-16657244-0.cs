    void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (HasChanges())
        {
            DialogResult result = MessageBox.Show("There are unsaved changes. Do you want to save before closing?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                e.Cancel = true; 
                if(!Save())
                {
                    MessageBox.Show("Your work could not be saved. Check your input/config and try again");
                    e.Cancel = true;
                }
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            } } }
