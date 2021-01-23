        public ObservableCollection<SomeDataSource> dataSource;
        
        public MainWindow()
        {
            InitializeComponent();
            this.dataSource = new ObservableCollection<SomeDataSource>();
            this.dataSource.Add(new SomeDataSource { Field = "123" });
            this.dataSource.Add(new SomeDataSource { Field = "1234" });
            this.dataSource.Add(new SomeDataSource { Field = "12345" });
            this.dataGrid1.ItemsSource = this.dataSource;
        }
    }
    public class SomeDataSource
    {
        public string Field {get;set;}
    }
     <DataGrid AutoGenerateColumns="False" Height="253" HorizontalAlignment="Left" Margin="27,24,0,0" Name="dataGrid1" VerticalAlignment="Top" Width="448">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="First" Binding="{Binding Path=Field, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
                </DataGrid.Columns>
     </DataGrid>
