    public static class WindowManager
    {
        public static void CloseWindow(Guid id)
        {
            foreach (Window window in App.Current.Windows)
            {
                var w_id = window.DataContext as IRequireViewIdentification;
                if (w_id != null && w_id.ViewID.Equals(id))
                {
                    window.Close();
                }
            }
        }
    }
