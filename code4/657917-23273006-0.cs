    //Main Window
    public class MainWindow{
      public void NavigatePage(Page page){
        YourFrameInstance.Navigate(page)
      }
    }
    //Your Page
    public class Page{
    
      private readonly Window _mainWindow;
      public Page(Window mainWindow){
        _mainWindow = mainWindow;
      }
      void Button_Click(object sender, RoutedEventArgs e){
        var page = new Page(_mainWindow);
        _mainWindow.NavigatePage(page);
      }
    }
