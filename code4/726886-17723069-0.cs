    public class MainViewModel : ViewModelBase {
    
    
        private  XmlDocument  xDoc;
        public  XmlDocument  XDoc {
          get {
            return xDoc;
          }
          set {
            xDoc = value;
            RaisePropertyChanged( "XDoc" );
          }
        }
    
        public MainViewModel( ) {
          Data d = new Data( );
          d.int1 = 12;
          d.int2 = 20;
          d.str = "Hello World";
         
    
          XmlSerializer serializer = new XmlSerializer( d.GetType( ) );
          StringWriter strWriter = new StringWriter( );
          serializer.Serialize( strWriter, d );
          XDoc = XDocument.Parse( strWriter.ToString( ) ).ToXmlDocument () ;   
        }
      }
     <TreeView Grid.Row="2" Grid.ColumnSpan="2" Name="xmlTree" 
                   ItemsSource="{Binding XDoc}" ItemTemplate="{StaticResource treeViewTemplate}"/>
