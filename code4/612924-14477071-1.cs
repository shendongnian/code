    private void bg6_Click(object sender, RoutedEventArgs e)
    {
       myGrid.DataContext=new myImagePresenterClass(new Uri("\\PhoneApp2\\PhoneApp2\\Assets\\bg\\bg5.jpg"), Visibility.Visible)
    }
    
    public class myImagePresenterClass:INotifyPropertyChanged
    {
    private URI sourceProperty
    Public URI SourceProperty
    {
    get
     {
      return sourceProperty;
     }
    set
     {
       sourceProperty=value;
       if(PropertyChanged!=null){PropertyChanged(this, new PropertyChangedEventArgs("SourceProperty"));}
     }
    }
 
    //Don't forget to implement the Visible property the same way as SourceProperty and the class constructor.
    }
