    public void GetScreenResolution()  
    {  
         string ScreenWidth = Application.Current.Host.Content.ActualWidth.ToString();  
         string ScreenHeight = Application.Current.Host.Content.ActualHeight.ToString();  
         MessageBox.Show(ScreenWidth + "*" + ScreenHeight);  
    }  
