    private void myProcess_Exited(object sender, System.EventArgs e)
    {
        Application.Current.Dispatcher.BeginInvoke(() => {
            _frm.change();
         });
    }
