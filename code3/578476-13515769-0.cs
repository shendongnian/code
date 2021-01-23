    if(listView1.Items.Cast<ListViewItem>().Any(i => i.SubItems[5].Text.ToLower().Contains("yes"))){
        labelContainsVideo2.Text = "GREAT";
        labelContainsVideo2.ForeColor = System.Drawing.Color.Green;
    }
    else
    {
        labelContainsVideo2.Text = "BAD";
        labelContainsVideo2.ForeColor = System.Drawing.Color.Red;
    }
