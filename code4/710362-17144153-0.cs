    var dict = new Dictionary<int,string>();
    dict.Add(1,"String Number 1");
    dict.Add(2,"String Number 2");
    dict.Add(3,"String Number 3");
    int test = int.Parse(textBox1.Text);
    MessageBox.Show(dict[test]);
    
