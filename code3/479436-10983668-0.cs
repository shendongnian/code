    void listBox1_KeyDown(object sender, KeyEventArgs e) {
      if (e.Control && e.KeyCode == Keys.Down) {
        e.SuppressKeyPress = true;
        if (listBox1.SelectedIndices.Count > 0 && 
            listBox1.SelectedIndices[listBox1.SelectedIndices.Count - 1] < listBox1.Items.Count-1) {
          List<int> selected = new List<int>();
          for (int i = 0; i < listBox1.SelectedIndices.Count; i++) {
            selected.Add(listBox1.SelectedIndices[i]);
          }
          listBox1.SelectedIndices.Clear();
          for (int i = selected.Count - 1; i >= 0; i--) {
            object listboxItem = listBox1.Items[selected[i] + 1];
            listBox1.Items[selected[i] + 1] = listBox1.Items[selected[i]];
            listBox1.Items[selected[i]] = listboxItem;
            listBox1.SelectedIndices.Add(selected[i] + 1);
          }
        }
      }
    }
