    private List<int> _counts = new List<int>();
    private void button1_Click(object sender, EventArgs e)
    {
        listBox1.Items.Clear();
        foreach (var i in numbers())
        {
            listBox1.Items.Add(i);
        }
    }
    private List<int> numbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            _counts.Add(i);
        }
        return counts;
    }
