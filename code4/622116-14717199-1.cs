    private async void Form1_DoubleClick(object sender, EventArgs e)
    {
        var tasks = new List<Task<string>>();
        for (int x = 0; x < listBox1.Items.Count; x++)
        {
            tasks.Add(RunList(x));
        }
        await Task.WhenAll(tasks);
    }
