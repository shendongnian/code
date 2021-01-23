        public Form1()
        {
            InitializeComponent();
            ListBoxWithTitle newitem = new ListBoxWithTitle();
            newitem.Size = new Size(200, 200);
            newitem.Location = new Point(20, 20);
            newitem.TitleLabelText = "Test";
            this.Controls.Add(newitem);
        }
