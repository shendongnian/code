        public TransprtScrcn()
        {
            InitializeComponent();
            this.BackColor = Color.Red;
            this.TransparencyKey = Color.Red;
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, e.ClipRectangle);
        }
    }
}
