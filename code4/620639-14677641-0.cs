    private void button12_Click(object sender, EventArgs e)
    {
        int sum = 0;
        foreach (ListViewItem o in lsvMain.Items)
        {
            int value;
            if (int.TryParse(o.SubItems[8].Text, out value))
                sum += value;
        }
        textBox1.Text = sum.ToString();
    }
