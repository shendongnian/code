     static public class WorkItemExecutionDecider
    {
        private static bool allowNextProcess = true;
        private static bool _touchupOccured = false;
        static WorkItemExecutionDecider()
        {
            Application.Current.MainWindow.TouchDown += onTouchDown;
            Application.Current.MainWindow.TouchUp += onTouchUp;
        }
        private static void onTouchUp(object sender, System.Windows.Input.TouchEventArgs e)
        {
            _touchupOccured = true;
        }
        private static void onTouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            _touchupOccured = false;
        }
        public static void SubmitWorkItem(Action action, System.Windows.Threading.DispatcherPriority priority)
        {
            if (allowNextProcess && !_touchupOccured)
            {
                allowNextProcess = false;
                System.Windows.Application.Current.Dispatcher.BeginInvoke(
                        priority,
                              action
                                    ).Completed += dispatcherOperation_Completed;
            }
        }
        static void dispatcherOperation_Completed(object sender, EventArgs e)
        {
            allowNextProcess = true;
        }
    }
