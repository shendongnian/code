    public class PressableButton : Button
    {
        private Timer _timer = new Timer() { Interval = 10 };
    
        public PressableButton()
        {
            _timer.Tick += new EventHandler(Timer_Tick);
        }
    
        private void Timer_Tick(object sender, EventArgs e)
        {
            OnClick(EventArgs.Empty);
        }
    
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            _timer.Start();
        }
    
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _timer.Stop();
        }      
    }
