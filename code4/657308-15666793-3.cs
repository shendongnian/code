    private void button6_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem eachItem in listView1.SelectedItems)
      {
        listView1.Items.Remove(eachItem);
        if (pths.Any(o => o == eachItem.Text))
        {
            pths.Remove(eachItem.Text);
        }
        if (rec.Any(o => o == eachItem.Text))
        {
            rec.Remove(eachItem.Text);
        }
      }
    }
