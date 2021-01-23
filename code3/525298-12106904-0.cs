    private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e) {
        string selectedText = comboBox1.SelectedText;
        string categoryId  = selectedText.Substring(0, selectedText.IndexOf(" "));
        MesasgeBox.Show(categoryId);
    }
