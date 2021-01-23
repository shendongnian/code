    public class MyListBox : ListBox
    {
      public MyListBox()
      {
          AddHandler(FrameworkElement.LoadedEvent, new RoutedEventHandler(ControlIsLoaded));
      }
      
      private void ControlIsLoaded(object sender, RoutedEventArgs e)
      {
          var canvas = VisualTreeHelper.GetChild(this.Template.FindName("PART_ItemsPresenter", this) as DependencyObject, 0);
      }
    }
