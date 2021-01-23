    // don't forget: using System.Runtime.InteropServices;
    class GlowingButton : System.Windows.Forms.Button
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand,
                                                 StringBuilder strReturn,
                                                 int iReturnLength,
                                                 IntPtr hwndCallback);
        public string SongURL { get; set; }
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
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.BackgroundImage = Winforms_Demo.Properties.Resources.bg;
            if (!string.IsNullOrEmpty(SongURL))
            {
                mciSendString("open \"" + SongURL + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
                mciSendString("play MediaFile", null, 0, IntPtr.Zero);
            }
        }
    }
