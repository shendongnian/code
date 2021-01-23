    private void viewImagesToolStripMenuItem_Click(object sender, EventArgs e)
     {
        DialogResult dr=openfd.ShowDialog();
        if(dr==DialogResult.Ok)
        {   
           richTextBox1.LoadFile(openfd.FileName,RichTextBoxStreamType.PlainText);           
        }
        else
        {
          MessageBox.Show("No file Selected!!");
        }
    }
