    private void button1_Click(object sender, EventArgs e)
    {
        ArrayList tmpArr = new ArrayList();
        foreach (object obj in listBox1.SelectedItems)
        {
            listBox2.Items.Add(obj);
            tmpArr.Add(obj);
        }
        foreach (object obj in tmpArr.ToArray())
        {
            listBox1.Items.Remove(obj);
        }
    }
