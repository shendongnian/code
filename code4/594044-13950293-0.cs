    class TwoColorButton : Button
    {
        private int stateCounter = 0;
        private Color[] states = new Color[] { Color.Black, Color.Red };
        public TwoColorButton()
            : base()
        {
            this.BackColor = states[stateCounter];
            this.Click += this.clickHandler;
        }
        protected void clickHandler(object sender, EventArgs e)
        {
            stateCounter = stateCounter == 0 ? 1 : 0;
            this.BackColor = states[stateCounter];
        }
    }
