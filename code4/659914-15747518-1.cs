        Panel panel = new Panel();
        Label lbl = new Label();
        public Form1()
        {
            InitializeComponent(); 
            panel.BackColor = Color.Gray;
            panel.Height = 20;
            panel.Width = 300;
            lbl.Text = "I was created using Code Behind";
            panel.Controls.Add(lbl);
            dynDiv.Panel1.Controls.Add(panel);
        }
