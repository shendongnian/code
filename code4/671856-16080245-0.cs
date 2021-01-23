    Timer t = new Timer();
    Form_Load()
    {
        t.Interval = 1000;
        t.Start();
    }
    static void t_Elapsed(object sender, ElapsedEventArgs e)
    {
        //One time event
        t.Stop();
        using (Graphics gr = progressBar1.CreateGraphics())
        {
            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
            sf.Alignment = StringAlignment.Center;
            gr.DrawString("hello world", 
                new Font("Arial", 10.0f, FontStyle.Regular),
                new SolidBrush(Color.Black), 
                progressBar1.ClientRectangle, 
                sf);                
        }
    }
