        string sVal = "";
        public Form1()
        {
            InitializeComponent();
            this.Activated += new EventHandler(Form1_GotFocus);
            this.Deactivate += new EventHandler(Form1_LostFocus);
               
        }
        void Form1_LostFocus(object sender, EventArgs e)
        {
            sVal = Clipboard.GetText();
            Clipboard.Clear();
        }
        void Form1_GotFocus(object sender, EventArgs e)
        {
            Clipboard.SetText(sVal);
        }
        
