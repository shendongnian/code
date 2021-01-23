        public PlotArea()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MouseEnter += new EventHandler(PlotArea_MouseEnter);
        }
        void PlotArea_MouseEnter(object sender, EventArgs e)
        {
            MessageBox.Show("test");
        }
