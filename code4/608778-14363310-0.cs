     private System.Windows.Forms.TextBox filePathBox = new TextBox();
        public Form1()
        {
            InitializeComponent();
            PopulateControls("Something");
        }
        public void PopulateControls(string someText)
        {
            if (someText == "Something")
            {
                this.filePathBox.Location = new System.Drawing.Point(6, 61);
                this.filePathBox.Name = "filePathBox";
                this.filePathBox.Size = new System.Drawing.Size(220, 20);
                this.tabPage1.Controls.Add(this.filePathBox);
                this.filePathBox.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (filePathBox != null)
            {
                MessageBox.Show(filePathBox.Text);
            }
        }
