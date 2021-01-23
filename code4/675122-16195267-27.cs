    public RelayCommand<IClosable> CloseWindowCommand { get; private set; }
    public MainViewModel()
    {
        this.CloseWindowCommand = new RelayCommand<IClosable>(this.CloseWindow);
    }
    private void CloseWindow(IClosable window)
    {
        if (window != null)
        {
            window.Close();
        }
    }
