    public Form1()
            {
                InitializeComponent();
            }
    
            System.Windows.Forms.Timer trOriginal = new System.Windows.Forms.Timer();
            System.Windows.Forms.Timer trRemain = new System.Windows.Forms.Timer();
            double remain = 0;
            private void button1_Click(object sender, EventArgs e)
            {
                trOriginal.Interval = 1000;
                trRemain.Interval = 1;
                trOriginal.Tick += new EventHandler(trOriginal_Tick);
                trRemain.Tick += new EventHandler(trRemain_Tick);
                trOriginal.Start();
                trRemain.Start();
            }
    
            void trRemain_Tick(object sender, EventArgs e)
            {
                remain -= trRemain.Interval;
                Console.WriteLine("remain MS to next event : " + remain);
            }
    
            void trOriginal_Tick(object sender, EventArgs e)
            {
                remain = trOriginal.Interval;
            }
