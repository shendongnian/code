    public Form1()
    {
        InitializeComponent();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        Sample sample = new Sample();
        sample.SampleEvent += sample_SampleEvent;
        sample.SampleMethod();
    }
    private void sample_SampleEvent()
    {
        Console.WriteLine("SampleMethod has been executed and the method on the WinForm has been notified about it.");
    }
