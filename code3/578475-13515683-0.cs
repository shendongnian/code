    string message = "BAD";
    var msgColor = System.Drawing.Color.Red;
    foreach (ListViewItem item in listView1.Items)
    {
        if (item.SubItems[5].Text.Contains("Yes"))
        {
            message = "GREAT";
            msgColor = System.Drawing.Color.Green;
            break;   // no need to check any more items - we have a match!
        }
    }
    labelContainsVideo2.Text = message ;
    labelContainsVideo2.ForeColor = msgColor;
