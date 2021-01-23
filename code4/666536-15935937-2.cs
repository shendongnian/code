        public static void BeginInvokeAction(this Dispatcher dispatcher,
                                             Action action) 
        {
            Dispatcher.BeginInvoke(action);
        }
