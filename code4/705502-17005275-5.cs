    private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
            {
                int value = 0;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    value += int.Parse(listView1.Items[i].SubItems[e.Column].Text);
                }
    
                textBox1.Text = value.ToString();
            }
