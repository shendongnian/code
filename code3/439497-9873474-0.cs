        public Form1()
        {
            InitializeComponent();
            this.ResizeEnd += new EventHandler(Form1_ResizeEnd);
            
        }
        void Form1_ResizeEnd(object sender, EventArgs e)
        {
            //draw the image again using the related calculation
        }
