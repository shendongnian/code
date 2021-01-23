    public class SomeVal : INotifyPropertyChanged
    {
       public int ProgressValue{...}
    }
    
    datagrid.ItemsSource = new [] {new SomeVal()};
