    // This method opens a dialog and save the content of the passed RichTextBox
    private bool ShowRichTextBoxSaveDialog(RichTextBox richTextBox)
    {
        SaveFileDialog newFileDialog = new SaveFileDialog();
        newFileDialog.Filter = "PDF Files|*.pdf";
        newFileDialog.Title = "Save As...";
        newFileDialog.Filter = "*.pdf";
        // If the user confirm the dialog window...
        if (newFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                richTextBox.SaveFile(newFileDialog.FileName, RichTextBoxStreamType.PlainText);
                // Success!
                return true;
            }
            catch(Exception e)
            {
                // Error during saving!
                MessageBox.Show(String.Concat("Error during saving: ", e.Message));
                return false;
            }
        }
        else
                // Aborted by the user!
                return false;
    }
    private void button3_Click(object sender, EventArgs e)
    {
       // NEXT WILL SHOW UP 4 DIALOGS, FOR ASKING THE USER 4 FILES TO SAVE!
       this.ShowRichTextBoxSaveDialog(richTextBox1);
       this.ShowRichTextBoxSaveDialog(richTextBox3);
       this.ShowRichTextBoxSaveDialog(richTextBox4);
       
       // HERE I ALSO CHECK IF THE SAVING IS SUCCESSFUL..
       if (this.ShowRichTextBoxSaveDialog(richTextBox5))
           MessageBox.Show("Success in saving :)");
       else
           MessageBox.Show("Failure in saving :(");
    }
