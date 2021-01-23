        public void DoSomethingExecute(object param)
        {
            ToggleValue result = param as ToggleValue;
            if (result.Value == 16)
            {
                result.IsChecked = true;
            }
        }
