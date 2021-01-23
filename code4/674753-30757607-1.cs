    private SimpleButton selectedButton;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            xtraScrollableControl2.AllowDrop = true;
            xtraScrollableControl2.DragEnter += XtraScrollableControl_DragEnter;
            xtraScrollableControl2.DragDrop += XtraScrollableControl_DragDrop;
            xtraScrollableControl2.DragOver += XtraScrollableControl_DragOver;
        }
        private void XtraScrollableControl_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(Bitmap)) ? DragDropEffects.Copy : DragDropEffects.None;
        }
        private void XtraScrollableControl_DragDrop(object sender, DragEventArgs e)
        {
            
            var simpleButton = e.Data.GetData(e.Data.GetFormats()[0]) as SimpleButton;
            if (simpleButton == null) return;
            if (simpleButton.Parent != sender) 
            {
                var btn = new SimpleButton
                {
                    Dock = DockStyle.None,
                    Size = new Size(125, 50),
                    Text = simpleButton.Text,
                    Location = ((XtraScrollableControl) sender).PointToClient(new Point(e.X, e.Y)),
                    ImageList = simpleButton.ImageList, 
                    ImageIndex = simpleButton.ImageIndex,
                    ImageLocation = simpleButton.ImageLocation,
                    Parent = ((XtraScrollableControl)sender)
                };
                btn.MouseDown += simpleButton_MouseDown;
            
                ((XtraScrollableControl)sender).Controls.Add(btn);
            }
            else
            {
                ((XtraScrollableControl)sender).Controls.Remove(simpleButton);
                simpleButton.Location = ((XtraScrollableControl)sender).PointToClient(new Point(e.X, e.Y));
                ((XtraScrollableControl)sender).Controls.Add(simpleButton);
            }
            selectedButton = null;
        }
        private void XtraScrollableControl_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            selectedButton.Location = ((XtraScrollableControl)sender).PointToClient(new Point(e.X, e.Y));
        }
        private void simpleButton_MouseDown(object sender, MouseEventArgs e)
        {
            var btn = sender as SimpleButton;
            if (btn == null) return;
            selectedButton = btn;
            btn.DoDragDrop(btn, DragDropEffects.Copy);
        }
