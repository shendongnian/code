    public class CsUtil
    {
        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(
                DispatcherPriority.Background,
                new ThreadStart(DoNothing));
        }
        private static void DoNothing() 
        {
            // Just as it says, this method does nothing :-P
        }
    }
