    private Dictionary<string, int> Names = new Dictionary<string, int>();
    
    private void button1_Click(object sender, EventArgs e)
    {
        int value = 0;
        if (int.TryParse(textBox2.Text, out value))
        {
            if (!Names.ContainsKey(textBox1.Text))
            {
                Names.Add(textBox1.Text, value);
            }
        }
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        if (Names.Any())
        {
            int maxMoney = Names.Max(v => v.Value);
            var names = Names.Where(k => k.Value.Equals(maxMoney));
            foreach (var name in names)
            {
                // Names with the highest money value
            }
        }
    }
