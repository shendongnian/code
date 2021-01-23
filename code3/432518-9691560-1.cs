    public partial class MainWindow: Window
      {
        public MainWindow( )
        {
          InitializeComponent( );
          var persons = new System.Collections.ObjectModel.ObservableCollection<Person>();
          persons.Add( new Person( ) { FirstName = "Walter" , LastName = "Bishop" , Age = 63 } );
          persons.Add( new Person( ) { FirstName = "Peter" , LastName = "Bishop" , Age = 33 } );
          persons.Add( new Person( ) { FirstName = "Olivia" , LastName = "Dunham" , Age = 33 } );
          TestListBox.DataContext = persons;
        }
        private void TestListBox_MouseDoubleClick( object sender , MouseButtonEventArgs e )
        {
          if ( TestListBox.SelectedItem != null )
          {
            MessageBox.Show( (string)TestListBox.SelectedValue );
          }
        }
      }
    
      public class Person
      {
        public string FirstName { get; set; }
        public string LastName{get;set;}
        public int Age { get; set; }
      }
