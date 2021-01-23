    class ParentControl : ...
    {
        DependencyProperty HandleKeypadKeyClickCommand = ...;
        void Init()
        {
            HandleKeypadKeyClickCommand = new RelayCommand(new Action<SomeKeyIdentifier>(DoKeyPress));
        }
        ...
        void DoKeyPress(SomeKeyIdentifier key)
        {
             _Textbox.Text += key.Char;
        }
        ...
    }
