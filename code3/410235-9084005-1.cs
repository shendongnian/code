    partial class YourForm : Form
    {
        string filePath;
        private void SaveMyFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                SaveFileDialog saveFile1 = new SaveFileDialog();
                saveFile1.DefaultExt = "*.rtf";
                saveFile1.Filter = "RTF Files|*.rtf";          
                if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                    saveFile1.FileName.Length > 0)
                {
                    filePath = saveFile1.FileName;
                }
                else return;
            }
            try
            {
                richTextBox1.SaveFile(filePath, RichTextBoxStreamType.PlainText);
            }
            catch (Exception ee)
            {
                // Put exception handling code here
            }
        }
    }
        
