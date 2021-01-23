        public Form1() {
            InitializeComponent();
            WireDragDrop(this.Controls);
        }
        private void WireDragDrop(Control.ControlCollection ctls) {
            foreach (Control ctl in ctls) {
                ctl.AllowDrop = true;
                ctl.DragEnter += ctl_DragEnter;
                ctl.DragDrop += ctl_DragDrop;
                WireDragDrop(ctl.Controls);
            }
        }
        void ctl_DragDrop(object sender, DragEventArgs e) {
            // etc..
        }
        void ctl_DragEnter(object sender, DragEventArgs e) {
            // etc..
        }
