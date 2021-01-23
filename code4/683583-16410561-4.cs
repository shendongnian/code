    public delegate void MyObjectFinished_EventHandler(object source, EventArgs e);
        public event MyObjectFinished_EventHandler OnFinished;
        public MyObject()
        {
        }
        private void Finished()
        {
            //do some clean up stuff
        }
        public void DoStuff()
        {
            //do stuff until finished
            Finished();
            OnFinished(this, new EventArgs());
        }
