    List<string> selectedList = new List<string>();
    foreach (var item in listBox1.SelectedItems) {
       selectedList.Add(item.ToString());
    }
    if (selectedList.Count() == 0) { return; }
    MessageBox.Show("Selected Items: " + Environment.NewLine +
            string.Join(Environment.NewLine, selectedList));
