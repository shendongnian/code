    static class ObservableCollectionExtensions
    {
        internal static void InvokeAdd<T>(this ObservableCollection<T> self, T item)
        {
            Application.Current.Dispatcher.Invoke((Action<T>)self.Add, item);
        }
        internal static void BeginInvokeAdd<T>(this ObservableCollection<T> self, T item)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action<T>(self.Add), item);
        }
    }
