        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged == null)
            {
                return;
            }
            Control c = ControlBase.sDummyControl;
            if (c == null)
            {
                PropertyChanged(sender, e);
            }
            else
            {
                if (c.InvokeRequired)
                {
                    c.BeginInvoke(new PropertyChangedEventHandler(RaisePropertyChanged), new object[] { sender, e });
                }
                else
                {
                    PropertyChanged(sender, e);
                }
            }
        }
