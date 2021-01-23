    System.Windows.Forms.Timer t;
    public Form1()
    {
        InitializeComponent();
        t = new System.Windows.Forms.Timer();
        t.Interval = 1000;
        t.Tick += new EventHandler(t_Tick);
    }
    void t_Tick(object sender, EventArgs e)
    {
        for(int i = 0;i<count;i++)//you must add here only those walid strings, can't use foreach
            lbDebug.Items.Add(item);
        count = 0;
    }
    static int count = 0;
    static string[] items = new string[5];
    void slotUtil_newLogMessage(object sender, slotUtils.LogEventArgs e)
    {
                t.Stop();
                items[count++] = e.logMsg;
                if (count >= items.Length)
                {
                    foreach (string item in items)
                        lbDebug.Items.Add(item);
                    count = 0;
                }
                else
                {
                    t.Start();
                }
     }
