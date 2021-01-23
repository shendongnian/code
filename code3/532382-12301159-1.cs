    public void LoadFrom(List<randomClass1> items) {
      for (int i = 0; i < items.Count; ++i) {
        randomClass1 rc = items[i];
        checkedListBox1.Items.Add(rc.Name);
        checkedListBox1.SetItemChecked(i, rc.IsChecked);
      }
    }
