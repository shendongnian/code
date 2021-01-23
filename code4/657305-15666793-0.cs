    private void button6_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem eachItem in pths.SelectedItems)
      {
        pths.Items.Remove(eachItem);
      }
      foreach (ListViewItem eachItem in rec.SelectedItems)
      {
        rec.Items.Remove(eachItem);
      }
    }
