    private void button1_Click(object sender, EventArgs e) {
      using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
        if (fbd.ShowDialog() == DialogResult.OK) {
          UpdateComboBox(fbd.SelectedPath);
        }
      }
    }
    private void UpdateComboBox(string folderPath) {
      comboBox1.Items.Clear();
      foreach (string fileName in Directory.GetFiles(folderPath)) {
        comboBox1.Items.Add(Path.GetFileName(fileName));
      }
    }
