     /// <summary>
    /// a messagebox that can be opened from any thread and can still be a child of the 
    /// main window or the dialog (or whatever) 
    /// </summary>
    public class ThreadIndependentMB
    {
        private readonly Dispatcher uiDisp;
        private readonly Window ownerWindow;
        public ThreadIndependentMB(Dispatcher UIDispatcher, Window owner)
        {
            uiDisp = UIDispatcher;
            ownerWindow = owner;
        }
        public void Show(string msg)
        {
            if (ownerWindow!=null)
            uiDisp.Invoke(new Action(() =>
            {
                MessageBox.Show(ownerWindow, msg, "title (replace)");
            }));
            else
                uiDisp.Invoke(new Action(() =>
                {
                    MessageBox.Show( msg, "title (replace)");
                }));
        }
        public MessageBoxResult Show(string msg, MessageBoxButton buttons)
        {
            MessageBoxResult resmb = new MessageBoxResult();
            if (ownerWindow != null)
            uiDisp.Invoke(new Action(() =>
            {
                resmb = MessageBox.Show(ownerWindow, msg, "title (replace)", buttons);
            }));
            else
                uiDisp.Invoke(new Action(() =>
                {
                    resmb = MessageBox.Show(msg, "title (replace)", buttons);
                }));
            return resmb;
        }
        public MessageBoxResult Show(string msg, string caption, MessageBoxButton buttons)
        {
            MessageBoxResult resmb = new MessageBoxResult();
            if (ownerWindow != null)
            uiDisp.Invoke(new Action(() =>
            {
                resmb = MessageBox.Show(ownerWindow, msg, caption, buttons);
            }));
            else
                uiDisp.Invoke(new Action(() =>
                {
                    resmb = MessageBox.Show( msg, caption, buttons);
                }));
            return resmb;
        }
        public MessageBoxResult Show(string msg, string caption, MessageBoxButton buttons,        
                                     MessageBoxImage image)
        {
            MessageBoxResult resmb = new MessageBoxResult();
            if (ownerWindow != null)
            uiDisp.Invoke(new Action(() =>
            {
                resmb = MessageBox.Show(ownerWindow, msg, caption, buttons, image);
            }));
            else
                uiDisp.Invoke(new Action(() =>
                {
                    resmb = MessageBox.Show( msg, caption, buttons, image);
                }));
            return resmb;
        }
    }
