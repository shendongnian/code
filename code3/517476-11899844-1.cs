    List<string> lines = File.ReadAllLines("C:\\message.txt").ToList();
    foreach (ListViewItem selectedItem in lvwMessages.SelectedItems)
      if (lines.Contains(selectedItem.Text))
        lines.Remove(selectedItem.Text);
    
