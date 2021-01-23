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
        public MessageBoxResult Show(string msg, string caption="",
            MessageBoxButton buttons=MessageBoxButton.OK,
            MessageBoxImage image=MessageBoxImage.Information)
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
