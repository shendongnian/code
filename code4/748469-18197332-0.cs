    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK) {
            using (var openFile = new StreamReader(openFileDialog1.FileName)) {
                getRichTextBox().Text = OpenFile.ReadToEnd();
            }
        }
    }
