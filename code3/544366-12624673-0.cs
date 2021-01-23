        private void dataGridView_liste_DataBindingComplete(object sender,
          DataGridViewBindingCompleteEventArgs e)  
        {
            Task t = Task.Factory.StartNew(() =>
            {
                // do your processing here - remember to call Invoke or BeginInvoke if
                // calling a UI object.
            });
            t.ContinueWith((Success) =>
            {
                // callback when task is complete.
            }, TaskContinuationOptions.NotOnFaulted);
            t.ContinueWith((Fail) =>
            {
                //log the exception i.e.: Fail.Exception.InnerException);
            }, TaskContinuationOptions.OnlyOnFaulted);
        }
