    public RelayCommand CloseWindow;
    Constructor()
    {
        CloseWindow = new RelayCommand(CloseWin);
    }
    
    public void CloseWin(object obj)
    {
        Window win = obj as Window;
        win.Close();
    }
    
