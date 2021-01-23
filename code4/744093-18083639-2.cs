        // Your UI thread should already have a Dispatcher object. If you do this elsewhere, then you will need your class to inherit DispatcherObject.
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
