        public Form()
        {
            InitializeComponent();
            var panel = new System.Windows.Forms.Panel();
            panel.Location = new System.Drawing.Point(82, 132);
            panel.Size = new System.Drawing.Size(200, 100);
            panel.Click += new System.EventHandler(this.panel_Click);
            this.Controls.Add(this.panel);
        }
        
        private void panel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.MousePosition.ToString());
        }
