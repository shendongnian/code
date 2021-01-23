     private void Form1_Load(object sender, EventArgs e)
        {
            PrintClass p = new PrintClass();
            BtnPrint.Click += p.printEventHandler;
            //subscrite the displayevent method to action delegate
            p.DisplayDelegate += DisplayEvent;
           
        }
        public void DisplayEvent(string s)
        {
            Invoke(new Action(() => TboxPrint.AppendText(s)));
        }
