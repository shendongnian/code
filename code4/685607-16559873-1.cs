private void button6_Click(object sender, EventArgs e)
    {
        if (t == null)
        {
            MessageBox.Show("Click on LoadFile Button,Please.");
            return;
        }
        if (textBox4.Text == "")
        {
            MessageBox.Show("Enter your Boolean Query");
            return;
        }
        listBox1.Items.Clear();
        DateTime dt = DateTime.Now;
        
        List<int> lst = t.ProcessQuery(textBox4.Text);
        count = 0;
        if (lst != null)
        {
            foreach (int a in lst)
            {
                listBox1.Items.Add(t.documentContentList[count]);
            }
            count++;
        }
        else
        {
            listBox1.Items.Add("No Search Result Found");
        }
        label1.Text = "Search = " + listBox1.Items.Count + " items, " + DateTime.Now.Subtract(dt).TotalSeconds + " s";
    }
