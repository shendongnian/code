    private void Form1_Load(object sender, EventArgs e)
    {
        Progress<string> progress = new Progress<string>();
        progress.ProgressChanged += (s, data) =>
        {
            textBox1.AppendText(data);
        };
        Thread tcpListener = new Thread(() => ListenForData(progress));
        tcpListener.Start();
    }
    private void ListenForData(IProgress<string> progress)
    {
        while (true)
        {
            Thread.Sleep(1000);//placeholder for real IO to get data
            progress.Report("data");
        }
    }
