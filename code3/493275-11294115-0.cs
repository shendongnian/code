        public Form1() {
            InitializeComponent();
            Application.Idle += UpdateTextLabel;
            this.FormClosed += delegate { Application.Idle -= UpdateTextLabel; };
        }
        void UpdateTextLabel(object sender, EventArgs e) {
            // etc..
        }
