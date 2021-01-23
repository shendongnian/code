    listBox1.DataSource = new string[] { "AAAA", "BBBB", "CCCC", "DDDD", "EEEE" };
    listBox2.DataSource = new string[] { "AAAA", "BBBB", "CCCC", "DDDD", "EEEE" };
    // inline event handlers
    listBox1.Click += (s,e)=>{
     listBox2.SelectedIndex = -1; 
    };
    listBox2.Click += (s,e) =>
    {
     listBox1.SelectedIndex = -1; 
    };
