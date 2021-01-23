        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Debug.Write("backgroundWorker_RunWorkerCompleted");
            if (e.Cancelled)
            {
                contents = "Cancelled get contents.";
                NotifyPropertyChanged("Contents");
            }
            else if (e.Error != null)
            {
                contents = "An Error Occured in get contents";
                NotifyPropertyChanged("Contents");
            }
            else
            {
                contents = (string)e.Result;
                if (contentTabSelectd) NotifyPropertyChanged("Contents");
            }
        }
