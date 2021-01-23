    richTextBox2.Text = String.Empty;
    foreach (ListViewItem item in listView1.Items)
    {
        if (item.Checked)
        {
            richTextBox2.Text += item.SubItems[1].Text + Environment.NewLine;
        }
    }
