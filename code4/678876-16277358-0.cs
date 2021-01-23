    int timerTicks;
    int waitUntill;
    public Form1()
    {
        InitializeComponent();
        timer1.Start();
        waitUntill = 10; 
        //10 = 1 second. Change this to decide how long the application will wait.
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (!timer1.Enabled)
            timer1.Start();
        timerTicks = 0;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        timerTicks++;
        if (timerTicks > waitUntill)
        {
            timer1.Stop();
            method(textbox1.Text);
        }
    }
    private void method(string word)
    {
        //Put the code that connects and searches through the database here..
    }
