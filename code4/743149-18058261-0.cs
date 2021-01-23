            ComboBoxItem item = this.cboForm.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                MessageBox.Show(item.Content.ToString());
            }
