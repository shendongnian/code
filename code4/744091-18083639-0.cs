        private DispatcherFrame ThisFrame;
    
        public void Main()
        {
            // Pausing the Thread
            Pause();
        }
    
        public void Pause()
        {
            ThisFrame = new DispatcherFrame(true);
            Dispatcher.PushFrame(ThisFrame);
        }
    
        public void UnPause()
        {
            if (ThisFrame != null && ThisFrame.Continue)
            {
                 ThisFrame.Continue = false;
                 ThisFrame = null;
            }
        }
