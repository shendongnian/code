        public Form1()
        {
            InitializeComponent();
        }
        int A, B;
        string Output;
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                while (A == B)
                {
                    Random r = new Random();
                    A = r.Next(1, 6);
                }
                Output = Output + A;
                B = A;
            }
            textBox1.Text = Output;
        }
