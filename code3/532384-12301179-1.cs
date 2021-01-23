    private void button1_Click(object sender, EventArgs e)
    {
        var list = new List<bool>();
        for (int i = 0; i < checkedListBox1.Items.Count; ++i)
        {
            list.Add(checkedListBox1.GetItemChecked(i));
        }
        Form2 f2 = new Form2();
        f2.Show();
        f2.SetList(list);
    }
