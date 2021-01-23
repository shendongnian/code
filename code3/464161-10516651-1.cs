    // this should be added:
    ComboBoxItem addItem = new ComboBoxItem("test", "test item");
    if (!cb.Items.Contains(addItem)) {
      cb.Items.Add(addItem);
    }
    // this should not be added:
    ComboBoxItem testItem = new ComboBoxItem("test", "duplicate item");
    if (!cb.Items.Contains(testItem)) {
      cb.Items.Add(testItem);
    }
