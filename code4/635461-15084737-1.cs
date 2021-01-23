    StringBuilder message = new StringBuilder();
    foreach (object selectedItem in listBox1.SelectedItems)
    {
        message.AppendLine(selectedItem.ToString());
    }
    MessageBox.Show(message.ToString());
