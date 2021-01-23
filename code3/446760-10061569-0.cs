    void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
        if (e.Exception is CommunicationObjectFaultedException) { //|| e.Exception is InvalidOperationException) {
            Reconnect();
            e.Handled = true;
        }
        else {
            MessageBox.Show(string.Format("An unexpected error has occured:\n{0}.\nThe application will close.", e.Exception));
            Application.Current.Shutdown();
        }
    }
