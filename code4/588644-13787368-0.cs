    private void Form1_Load(object sender, EventArgs e)
    {
        System.Threading.Tasks.Task t = new Task(() => myMethod());
        t.Start();
    }
