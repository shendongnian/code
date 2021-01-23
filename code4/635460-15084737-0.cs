    StringBuilder message = new StringBuilder();
    foreach (object selectedItem in listBox1.SelectedItems)
    {
        message.Append(selectedItem.ToString() + Environment.NewLine);
    }
    MessageBox.Show(message.ToString());
