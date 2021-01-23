    public abstract class CustomTooltip : Form
    {
        #region Static
        protected static readonly int FadeInterval = 25;
        protected static readonly IntPtr HWND_TOPMOST = (IntPtr)(-1);
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOACTIVATE = 0x0010;
        private const int WS_POPUP = unchecked((int)0x80000000);
        private const int WS_EX_TOPMOST = 0x00000008;
        private const int WS_EX_NOACTIVATE = 0x08000000;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        #endregion
        protected Dictionary<object, object> subscriptions;
        protected Timer popupTimer;
        protected Timer fadeTimer;
        protected bool isFading = false;
        protected int fadeDirection = 1;
        [DefaultValue(500)]
        /// <summary>
        /// Delay in milliseconds before the tooltip is shown.  0 means no delay.
        /// </summary>
        public int PopupDelay
        {
            get
            {
                return _popupDelay;
            }
            set
            {
                _popupDelay = value;
                if (value > 0)
                    popupTimer.Interval = value;
                else
                    popupTimer.Interval = 1;
            }
        }
        private int _popupDelay = 500;
        [DefaultValue(0)]
        /// <summary>
        /// How long to spend fading in and out in milliseconds.  0 means no fade.
        /// </summary>
        public int FadeTime
        {
            get
            {
                return _fadeTime;
            }
            set
            {
                _fadeTime = value;
            }
        }
        private int _fadeTime = 0;
        public virtual new object Tag
        {
            get
            {
                return base.Tag;
            }
            set
            {
                base.Tag = value;
                OnTagChanged(EventArgs.Empty);
            }
        }
        public CustomTooltip()
        {
            this.SetStyle(ControlStyles.Selectable, false);
            subscriptions = new Dictionary<object, object>();
            popupTimer = new Timer();
            popupTimer.Interval = PopupDelay;
            popupTimer.Tick += new EventHandler(popupTimer_Tick);
            fadeTimer = new Timer();
            fadeTimer.Interval = FadeInterval;
            fadeTimer.Tick += new EventHandler(fadeTimer_Tick);
            this.Visible = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.Manual;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_POPUP;
                cp.ExStyle |= WS_EX_TOPMOST | WS_EX_NOACTIVATE;
                return cp;
            }
        }
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }
        protected virtual void Subscribe(Control control, object tag)
        {
            subscriptions.Add(control, tag);
            control.MouseEnter += new EventHandler(Item_MouseEnter);
            control.MouseLeave += new EventHandler(Item_MouseLeave);
        }
        protected virtual void Subscribe(ITooltipTarget item, object tag)
        {
            subscriptions.Add(item, tag);
            item.MouseEnter += new EventHandler(Item_MouseEnter);
            item.MouseLeave += new EventHandler(Item_MouseLeave);
        }
        public virtual void Unsubscribe(Control control)
        {
            control.MouseEnter -= new EventHandler(Item_MouseEnter);
            control.MouseLeave -= new EventHandler(Item_MouseLeave);
            subscriptions.Remove(control);
        }
        public virtual void Unsubcribe(ITooltipTarget item)
        {
            item.MouseEnter -= new EventHandler(Item_MouseEnter);
            item.MouseLeave -= new EventHandler(Item_MouseLeave);
            subscriptions.Remove(item);
        }
        public void ClearSubscriptions()
        {
            foreach (object o in subscriptions.Keys)
            {
                if (o is Control)
                    Unsubscribe((Control)o);
                else if (o is ITooltipTarget)
                    Unsubscribe((ITooltipTarget)o);
            }
        }
        protected virtual void OnTagChanged(EventArgs e)
        {
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Item_MouseLeave(null, EventArgs.Empty);
        }
        private void Item_MouseEnter(object sender, EventArgs e)
        {
            Tag = subscriptions[sender];
            popupTimer.Start();
        }
        private void Item_MouseLeave(object sender, EventArgs e)
        {
            if (FadeTime > 0)
                FadeOut();
            else
                this.Hide();
            popupTimer.Stop();
        }
        protected virtual void FadeIn()
        {
            isFading = true;
            Opacity = 0;
            fadeDirection = 1;
            fadeTimer.Start();
        }
        protected virtual void FadeOut()
        {
            isFading = true;
            Opacity = 1;
            fadeDirection = -1;
            fadeTimer.Start();
        }
        private void popupTimer_Tick(object sender, EventArgs e)
        {
            if (isFading)
                this.Hide();
            if (FadeTime > 0)
                FadeIn();
            Location = new Point(Cursor.Position.X, Cursor.Position.Y + Cursor.Size.Height);
            SetWindowPos(Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE);
            Show();
            popupTimer.Stop();
        }
        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            if (Opacity == 0 && fadeDirection == -1)
            {
                isFading = false;
                fadeTimer.Stop();
                this.Hide();
            }
            else if (Opacity == 1 && fadeDirection == 1)
            {
                fadeTimer.Stop();
                isFading = false;
            }
            else
            {
                double change = ((double)fadeTimer.Interval / (double)FadeTime) * (double)fadeDirection;
                Opacity += change;
            }
        }
    }
    public interface ITooltipTarget
    {
        event EventHandler MouseEnter;
        event EventHandler MouseLeave;
    }
