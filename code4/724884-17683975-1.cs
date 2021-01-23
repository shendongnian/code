XAML
    <Window x:Class="DataGridDynamicAddCol.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525" 
        WindowStartupLocation="CenterScreen" ContentRendered="Window_ContentRendered">
    
        <Grid>
            <DataGrid Name="DynamicColumnDataGrid" Loaded="DynamicColumnDataGrid_Loaded" AutoGenerateColumns="False"/>
        </Grid>
    </Window>
Code behind
    public partial class MainWindow : Window
    {        
        // Create class with data
        // Note: Each parameter contains a list of values for it.
        public class Person
        {
            public Person() 
            {
                FirstName = new List<string>();
                SecondName = new List<string>();
                Sample = new List<string>();
            }
            public List<string> FirstName { get; set; }
            public List<string> SecondName { get; set; }
            public List<string> Sample { get; set; }
        }
        // Number of columns
        const Int32 COLS = 3;
        // Number of rows
        const Int32 ROWS = 3;
        // Number repeats
        const Int32 RPTS = 3;
        // Array of headers
        string[] HeadersArray = new string[COLS] 
        { 
            "FirstName", 
            "SecondName", 
            "Sample"
        };
        // Array of values: Depends on the number of columns and rows
        // Note: The number of repetitions you can specify smaller amounts of data
        // If you specify more, then this place will be empty cells
        string[, ,] ValuesArray = new string[, ,] 
        {
            {
                { "Andy", "Caufmann", "Artist"},
                { "Sam", "Fisher", "Spy"},
                { "Ben", "Affleck", "Actor"}
            },
            {
                { "Jim", "Gordon", "Sniper"},
                { "Maria", "Gray", "Cleaner"},
                { "Katy", "Parry", "Artist"}
            },
            {
                { "Jack", "Rider", "Hunter"},
                { "Sven", "Vath", "DJ"},
                { "Paul", "Kalkbrenner", "Super DJ"}
            }
        };
        private List<Person> OnePerson;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            OnePerson = new List<Person>();
            // Create the columns
            for (int cols = 0; cols < COLS; cols++)
            {
                OnePerson.Add(new Person());
            }
            // Create the rows
            for (int cols = 0; cols < COLS; cols++)
            {
                for (int rows = 0; rows < ROWS; rows++)
                {
                    OnePerson[rows].FirstName.Add(ValuesArray[cols, rows, 0]);
                    OnePerson[rows].SecondName.Add(ValuesArray[cols, rows, 1]);
                    OnePerson[rows].Sample.Add(ValuesArray[cols, rows, 2]);
                }
            }
            DynamicColumnDataGrid.ItemsSource = OnePerson;
        }
        private void DynamicColumnDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // Create dynamically the columns and rows
            for (int rpts = 0; rpts < RPTS; rpts++ )
            {
                for (int cols = 0; cols < COLS; cols++)
                {
                    DataGridTextColumn MyTextColumn = new DataGridTextColumn();
                    MyTextColumn.Header = HeadersArray[cols];
                    // Binding values from HeadersArray
                    MyTextColumn.Binding = new Binding(String.Format("{0}[{1}]", 
                        new object[]
                        {
                            HeadersArray[cols], rpts
                        }
                    ));
                    // Add column in DataGrid
                    DynamicColumnDataGrid.Columns.Add(MyTextColumn);
                }
            }
        }
    }
Output
