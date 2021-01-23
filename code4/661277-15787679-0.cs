    class MyEventListenerClass
    {
         .....
        private void EventHandlerMethod(object sender, MyEventArgs E)
        {
            if (E.OriginalSender != this)
            { 
                do what is needed
            }
            else
            {
                got this message from myself in a circular way....discard it
            }
        }
         ......
    }
    class MyEventArgs : EventArgs
    {
        public object OriginalSender {get; private set;}
        public MyEventArgs(object OrigSender) : base ()
        {
            OriginalSender = OrigSender;
        }
    }
