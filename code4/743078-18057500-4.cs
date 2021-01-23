    class A : Control
    {
        public string Property
        {
            set 
            { 
                if (this.InvokeRequired) 
                {
                    this.Invoke((Action<string>)setProperty, value);
                    reutrn;
                }
                setProperty(value);
            }
        }
        private void setProperty string()
        {
            PropertyChanged(this, EventArgs.Empty); 
        }
    }
