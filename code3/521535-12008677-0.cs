    class GlowingButton : System.Windows.Forms.Button
    {
        public GlowingButton() : base()
        {
            this.BackgroundImage = Winforms_Demo.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackgroundImage = Winforms_Demo.Properties.Resources.bgGlow;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackgroundImage = Winforms_Demo.Properties.Resources.bg;
        }
    }
