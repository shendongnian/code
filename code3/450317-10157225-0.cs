        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                //If the Proxy object is living in a non-UI thread, use invoke
                if (c != null)
                {
                    c.BeginInvoke(new Action(() => handler(this, new PropertyChangedEventArgs(name))));
                }
                //Otherwise update directly
                else
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
        //Use this to reference the object on the UI thread when there is need to
        public Control C
        {
            set { c = value; }
        }
