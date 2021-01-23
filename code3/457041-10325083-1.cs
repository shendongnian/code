    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            this.dataGrid.ItemsSource = new ObservableCollection<Person>()
            {
                new Person() { Name = "John", Surname = "Doe" },
                new Person() { Name = "Jane", Surname = "Doe" }
            };
        }
    
        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var dataGridBoundColumn = e.Column as DataGridBoundColumn;
            if (dataGridBoundColumn != null)
            {
                var binding = dataGridBoundColumn.Binding as Binding;
                if (binding != null)
                {
                    binding.NotifyOnSourceUpdated = true;
                    binding.NotifyOnTargetUpdated = true;
                }
            }
        }
    
        private void OnDataGridCellSourceUpdated(object sender, DataTransferEventArgs e)
        {
            this.OnDataGridCellChanged((DataGridCell)sender);
        }
    
        private void OnDataGridCellTargetUpdated(object sender, DataTransferEventArgs e)
        {
            this.OnDataGridCellChanged((DataGridCell)sender);
        }
    
        private void OnDataGridCellChanged(DataGridCell dataGridCell)
        {
            // DataContext is MS.Internal.NamedObject for NewItemPlaceholder row.
            var person = dataGridCell.DataContext as Person;
            if (person != null)
            {
                var propertyName = ((Binding)((DataGridBoundColumn)dataGridCell.Column).Binding).Path.Path;
                var propertyValue = TypeDescriptor.GetProperties(person)[propertyName].GetValue(person);
                // TODO: do some logic here.
            }
        }
    }
