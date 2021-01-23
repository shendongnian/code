public class CollectionSrc
{
  public ObservableCollection&lt;...&gt; Col 
  { 
    get { return _col ?? (_col = new ObservableCollection&lt;...&gt;()); }
  }
}
In App.xaml
&lt;ns:CollectionSrc x:Key="ColSrc" /&gt; &lt;!--ns .. the namespace of CollectionSrc--&gt;
Now you can access ColSrc everywhere in the xaml code. E.g.
&lt;ListBox ItemsSource={Binding Col, Source={StaticResource ColSrc}} /&gt;
