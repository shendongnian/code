       public void GoNew()
        {
            var vm = new BViewModel(Path);
            Execute.OnUIThread(() =>
            {
                WindowManager.ShowWindow(vm, null, null);
                IsBusy = false;
                NotifyOfPropertyChange("IsBusy");
                Text = "";
                NotifyOfPropertyChange("Text");
            });
        }         
