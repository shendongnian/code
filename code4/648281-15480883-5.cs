        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(
                System.Windows.Threading.DispatcherPriority.Background, 
                new Action(delegate { }));
        }
