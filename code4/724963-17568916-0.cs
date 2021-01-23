    private Thread _Thread;
    public Form1()
    {
        InitializeComponent();
        _Thread = new Thread(OnThreadStart);
    }
    private void OnButton1Click(object sender, EventArgs e)
    {
        var state = _Thread.ThreadState;
        switch (state)
        {
            case ThreadState.Unstarted:
                _Thread.Start(listBox1);
                break;
            case ThreadState.WaitSleepJoin:
            case ThreadState.Running:
                _Thread.Suspend();
                break;
            case ThreadState.Suspended:
                _Thread.Resume();
                break;
        }
    }
    private static void OnThreadStart(object obj)
    {
        var listBox = (ListBox)obj;
        var someItems = Enumerable.Range(1, 10).Select(index => "My Item " + index).ToArray();
        foreach (var item in someItems)
        {
            listBox.Invoke(new Action(() => listBox.Items.Add(item)));
            Thread.Sleep(1000);
        }
        listBox.Invoke(new Action(() => listBox.Items.Clear()));
    }
