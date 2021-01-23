    private void button1_Click(object sender, EventArgs e) {
      ChangeCombos(this);
    }
    private void ChangeCombos(Control parent) {
      foreach (Control c in parent.Controls) {
        if (c.Controls.Count > 0) {
          ChangeCombos(c);
        } else if (c is ComboBox) {
          (c as ComboBox).SelectedValueChanged += comboBox1_SelectedValueChanged;
        }
      }
    }
