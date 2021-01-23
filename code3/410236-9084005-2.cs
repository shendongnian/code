    partial class YourForm : Form
    {
        Button saveFileAsButton; // Add this using the Forms Designer
        
        private void saveFileAsButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";          
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                saveFile1.FileName.Length > 0)
            {
                try
                {
                    richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
                    filePath = saveFile1.FileName;
                }
                catch (Exception ee)
                {
                    // Put exception handling code here (e.g. error saying file cannot be saved)
                }
            }
        }
    }
