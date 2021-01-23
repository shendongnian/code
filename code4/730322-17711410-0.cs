    private async void button1_Click(object sender, EventArgs e)
    {
        running = true;
        while (running)
        {
            //your code
            await System.Threading.Tasks.Task.Delay(4500);
        }
    }
