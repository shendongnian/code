    class ButtonClickRepeater
    {
        public event EventHandler Click;
        private Button button;
        private Timer timer;
        public ButtonClickRepeater(Button button, int interval)
        {
            if (button == null) throw new ArgumentNullException();
            this.button = button;
            button.MouseDown += new MouseEventHandler(button_MouseDown);
            button.MouseUp += new MouseEventHandler(button_MouseUp);
            button.Disposed += new EventHandler(button_Disposed);
            timer = new Timer();
            timer.Interval = interval;
            timer.Tick += new EventHandler(timer_Tick);
        }
        void button_MouseDown(object sender, MouseEventArgs e)
        {
            OnClick(EventArgs.Empty);
            timer.Start();
        }
        void button_MouseUp(object sender, MouseEventArgs e)
        {
            timer.Stop();
        }
        void button_Disposed(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            OnClick(EventArgs.Empty);
        }
        protected void OnClick(EventArgs e)
        {
            if (Click != null) Click(button, e);
        }
    }
