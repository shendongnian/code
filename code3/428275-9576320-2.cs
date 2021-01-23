        private void SaveAsItem_Click(object sender, EventArgs e)
    {
        saveFileDialog1.FileName = "untitled";
        saveFileDialog1.Filter = "Text (*.txt)|*.txt";
        if (saveFileDialog1.ShowDialog()==DialogResult.Cancel)
        {
            richTextBox1.Text = "CANCEL";
            issaved = false;
        }
        else
        {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(saveFileDialog1.FileName);
            issaved = true;
            SaveFile.WriteLine(richTextBox1.Text);
            SaveFile.Close();
        }
    }
