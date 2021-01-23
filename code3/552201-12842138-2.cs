    bool checkFlag = false;
    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e) {
      if (!checkFlag) {
        checkFlag = true;
        for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix) {
          if (ix != e.Index) {
            checkedListBox1.SetItemChecked(ix, false);
          }
        }
        checkFlag = false;
      }
    }
