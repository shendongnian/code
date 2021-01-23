    public partial class Form1 : Form
    {
        private Button[,] b;
        private const int WS_EX_NOACTIVATE = 0x08000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;
                p.ExStyle |= WS_EX_NOACTIVATE;
                return p;
            }
        }
        public Form1()
        {
            InitializeComponent();
            start();
        }
        public void start()
        {
            panel1.Controls.Clear();
            int m = 13;
            int n = 2;
            b = new Button[n, m];
            int x = 0;
            int i, j;
            int y = 0;
            // int count = 0;
            int chr1 = (int)'A';
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    //  count++;
                    b[i, j] = new Button();
                    b[i, j].SetBounds(x, y, panel1.Size.Width / m, panel1.Size.Height / n);
                    b[i, j].Name = i + "," + j;
                    b[i, j].Text = ((char)chr1).ToString();
                    b[i, j].Click += new EventHandler(ButtonClick);
                    panel1.Controls.Add(b[i, j]);
                    x = x + panel1.Size.Width / m;
                    chr1++;
                }
                y = y + panel1.Size.Height / n;
                x = 0;
            }
        }
        public void ButtonClick(Object sender, EventArgs e)
        {
            SendKeys.Send(((Control)sender).Text);
        }
    }
