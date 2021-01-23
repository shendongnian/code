        public void GoNew()
        {
            Execute.OnUIThread(() =>
            {
                WindowManager.ShowWindow(new BViewModel(Path), null, null);
                IsBusy = false;
                NotifyOfPropertyChange("IsBusy");
                Text = "";
                NotifyOfPropertyChange("Text");
            });
        }         
