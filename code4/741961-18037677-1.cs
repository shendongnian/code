    private void SelectedPrinter_TextChanged(object sender, EventArgs e) {
      listBoxBeltPrinters.SelectedIndex = -1;
      if (!String.IsNullOrEmpty(lblSelectedPrinter.Text)) {
        for (int index = 0; index < listBoxBeltPrinters.Items.Count; index++) {
          string item = listBoxBeltPrinters.Items[index].ToString();
          if (lblSelectedPrinter.Text == item) {
            listBoxBeltPrinters.SelectedItem = index;
            break;
          }
        }
      }
    }
