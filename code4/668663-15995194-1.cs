        public delegate void CustomKeyUpHandler(object sender, CustomKeyEventArgs e);
        public event CustomKeyUpHandler OnCustomKeyUp;
        private char lastChar;
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            lastChar = e.KeyChar;
            base.OnKeyPress(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if(OnCustomKeyUp != null)
                OnCustomKeyUp(this, new CustomKeyEventArgs(e.KeyData, lastChar));
            base.OnKeyUp(e);
        }
