    foreach (ListViewItem item in listView1.Items)
    {
      if (item.SubItems[5].Text.ToUpper().Contains("YES"))
      {
        // Do your work here
        labelContainsVideo2.Text = "GREAT";
        labelContainsVideo2.ForeColor = System.Drawing.Color.Green;
      }
      else
      {
        labelContainsVideo2.Text = "BAD";
        labelContainsVideo2.ForeColor = System.Drawing.Color.Red;
      }
    }
