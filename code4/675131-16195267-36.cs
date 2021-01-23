    public RelayCommand<ICloseable> CloseWindowCommand { get; private set; }
    public MainViewModel()
    {
        this.CloseWindowCommand = new RelayCommand<IClosable>(this.CloseWindow);
    }
    private void CloseWindow(ICloseable window)
    {
        if (window != null)
        {
            window.Close();
        }
    }
