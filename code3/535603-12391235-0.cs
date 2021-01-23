     string stuff = "This is some text that looks like it is being typed.";
     int pos = 0;
     Timer t;
     public Form1()
     {
         InitializeComponent();
         t = new Timer();
         t.Interval = 500;
         t.Tick += new EventHandler(t_Tick);
     }
     void t_Tick(object sender, EventArgs e)
     {
         if (pos < stuff.Length)
         {
             textBox1.AppendText(stuff.Substring(pos, 1));
             ++pos;
         }
         else
         {
             t.Stop();
         }
     }
     private void button1_Click(object sender, EventArgs e)
     {
         pos = 0;
         textBox1.Clear();
         t.Start();
     }
