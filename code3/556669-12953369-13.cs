        public void DoSomethingExecute(object param)
        {
            ToggleValue result = param as ToggleValue;
            if (result.Value == 16)
            {
                result.View.IsCheckedToogle1 = true;
                result.View.IsCheckedToogle2 = false;
                result.View.IsCheckedToogle3 = false;
                result.View.IsCheckedToogle4 = false;
            }
        }
