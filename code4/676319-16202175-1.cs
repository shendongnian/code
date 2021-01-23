    private async void button1_Click(object sender, EventArgs e)
    {
        var tasks = new List<Task>();
        for(int i = 0; i< 100; i++)
        {
            tasks.Add(Method1());
        }
        await Task.WhenAll(tasks);
        textbox1.Text = "Done!"; //or whatever you want to do when they're all done
    }
