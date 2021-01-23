    ListView listView1;
    private void init_listView1() {
      listView1.ItemActivate += new EventHandler(listView_Focus);
      listView1.GotFocus += new EventHandler(listView_Focus);
    }
    private void listView_Focus(object sender, EventArgs e) {
      int index = -1;
      if ((listView1.SelectedIndices != null) && (0 < listView1.SelectedIndices.Count)) {
        index = listView1.SelectedIndices[0];
        ListViewItem item = listView1.Items[index];
      } else {
        if (0 < listView1.Items.Count) {
          index = 0;
        }
      }
      if (-1 < index) {
        listView1.Items[index].Focused = true;
      }
    }
