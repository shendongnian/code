    public class ColorEventArgs : EventArgs
    {
        private Color newColor;
        public Color formColor
        {
            get { return this.newColor; }
            set { this.newColor = value; }
        }
    }
