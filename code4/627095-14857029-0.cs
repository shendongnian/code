    var name = txtBox1.Text.Split(' ')[0];
    if (string.IsNullOrEmpty(name))
    {
         return;
    }
    var items = listBox1.DataSource as List<string>;
    var count = items.Count(x => x.Split(' ')[0] == name);
    textBox2.Text = count.ToString();
