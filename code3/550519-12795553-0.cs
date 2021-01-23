    for (int i = 5; i < tabControl1.TabCount; i++)
    {
        if (tabControl1.TabPages[i] != null)
        {
            var textBox = tabControl1.TabPages[i].Controls.Find("TextBox1", false);
            //...
        }       
    }
