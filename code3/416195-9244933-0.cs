        string _sPing = "ping";
        string _sPong = "pong";
        bool bGoingUp = true;
        int iUBound = 15;
        int iCnt = 1;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bGoingUp)
            {
                label1.Text = " " + label1.Text;
                iCnt++;
            }
            else
            {
                label1.Text = label1.Text.Substring(1,label1.Text.Length - 1);
                iCnt--;
            }
            if (iCnt == iUBound)
            {
                bGoingUp = false;
                label1.Text = label1.Text.Replace(_sPing, _sPong);
            }
            else if (iCnt == 1)
            {
                bGoingUp = true;
                label1.Text = label1.Text.Replace(_sPong, _sPing);
            }
            
       }
