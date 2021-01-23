    private void Form1_Load(object sender, EventArgs e)
    {
        //Question #1 Pop Names in listbox
        for (int i = 0; i < names.Length; i++)
        {
            listBox1.Items.Add(names[i]);
            listBox2.Items.Add(names[i].Length);
        }
    }
