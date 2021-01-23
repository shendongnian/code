    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var records = new DataRecordCollection<DataRecord>(
                    new DataProperty("Name", typeof(string), false),
                    new DataProperty("Surname", typeof(string), true),
                    new DataProperty("Gender", typeof(char), false, new NameValueAttribute() { Name = "Male", Value = 'M' }, new NameValueAttribute() { Name = "Female", Value = 'F' }));
    
                for (int i = 0; i < 100; ++i)
                {
                    var record = new DataRecord();
                    record["Name"] = "Name " + i;
                    record["Surname"] = "Surname " + i;
                    record["Gender"] = i % 2 == 0 ? 'M' : 'F';
                    records.Add(record);
                }
    
                this.dataGrid.ItemsSource = records;
            }
    
            private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {
                e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;
    
                var propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
                var dataBoundColumn = (DataGridBoundColumn)e.Column;
    
                var comboBoxColumn = GenerateComboBoxColumn(propertyDescriptor, dataBoundColumn);
                if (comboBoxColumn != null)
                    e.Column = comboBoxColumn;
            }
    
            private static DataGridComboBoxColumn GenerateComboBoxColumn(PropertyDescriptor propertyDescriptor, DataGridBoundColumn dataBoundColumn)
            {
                var nameValueAttributes = propertyDescriptor.Attributes.OfType<NameValueAttribute>().ToArray();
    
                if (nameValueAttributes.Length > 0)
                    return new DataGridComboBoxColumn()
                    {
                        ItemsSource = nameValueAttributes,
                        DisplayMemberPath = "Name",
                        SelectedValuePath = "Value",
                        SelectedValueBinding = dataBoundColumn.Binding
                    };
                else
                    return null;
            }
        }
    }
