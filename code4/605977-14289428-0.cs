    private void Form1_Load(object sender, EventArgs e)
    {
        this.ControlBox = false;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.MinimumSize = this.MaximumSize = this.Size; 
        this.Text = "";                
    }
    const int WM_NCHITTEST = 0x0084;
    const int HTBOTTOM = 15;
    const int HTBOTTOMLEFT = 16;
    const int HTBOTTOMRIGHT = 17;
    const int HTLEFT = 10;
    const int HTRIGHT = 11;
    const int HTTOPLEFT = 13;
    const int HTTOPRIGHT = 14;
    const int HTTOP = 12;
    const int HTCLIENT = 1;
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == WM_NCHITTEST)
        {
            Console.WriteLine(m.Result.ToString());
            switch (m.Result.ToInt32())
            {
                case HTBOTTOM:
                case HTBOTTOMLEFT:
                case HTBOTTOMRIGHT:
                case HTLEFT:
                case HTRIGHT:
                case HTTOPLEFT:
                case HTTOPRIGHT:
                case HTTOP:
                    m.Result =(IntPtr) HTCLIENT;
                    break;
            }
        }
    }
