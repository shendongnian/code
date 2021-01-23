    public class MdiForm : System.Windows.Forms.Form
    {
        private static readonly float _bg_scale = FormGraphics.mdi_background.Width / (float)FormGraphics.mdi_background.Height;
        private MdiClient _mdi_client = null;
        private Image _background_cache = null;
        public MdiForm()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            Shown += MdiForm_Shown;
            SizeChanged += MdiForm_SizeChanged;
            IsMdiContainer = true;
        }
        private void MdiForm_Shown(object sender, EventArgs eventArgs)
        {
            foreach (MdiClient control in Controls.OfType<MdiClient>())
            {
                _mdi_client = control;
                control.Paint += MdiClient_Paint;
                control.BackColor = Color.White;
                
                //LA LA LA I CAN'T HEAR YOU
                //this DOES work and IS required to avoid flicker
                MethodInfo mInfoMethod = typeof(MdiClient).GetMethod(
                                                   "SetStyle",
                                                   BindingFlags.Instance | BindingFlags.NonPublic,
                                                   Type.DefaultBinder,
                                                   new[] { typeof(ControlStyles), typeof(bool) },
                                                   null);
                mInfoMethod.Invoke(control, new object[] {
                    ControlStyles.UserPaint |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.OptimizedDoubleBuffer, true });
            }
        }
        private void MdiClient_Paint(object sender, PaintEventArgs e)
        {
            if(_background_cache == null) { _background_cache = new Bitmap(FormGraphics.mdi_background, (int)(Height * _bg_scale), Height); }
            e.Graphics.DrawImageUnscaled(_background_cache, Point.Empty);
        }
        private void MdiForm_SizeChanged(object sender, EventArgs e)
        {
            if (_background_cache != null) { _background_cache.Dispose(); }
            _background_cache = null;
            if (_mdi_client != null) { _mdi_client.Invalidate(); }
        }
    }
