    using System;
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
            }
    
            private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {
                var propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
                var dataBoundColumn = (DataGridBoundColumn)e.Column;
    
                var comboBoxColumn = GenerateComboBoxColumn(propertyDescriptor, dataBoundColumn);
                if (comboBoxColumn != null)
                    e.Column = comboBoxColumn;
    
                if (IsReadOnlyProperty(propertyDescriptor))
                    e.Column.IsReadOnly = true;
            }
    
            private static DataGridComboBoxColumn GenerateComboBoxColumn(PropertyDescriptor propertyDescriptor, DataGridBoundColumn dataBoundColumn)
            {
                var nameValueAttributes = Attribute.GetCustomAttributes(propertyDescriptor.ComponentType.GetProperty(propertyDescriptor.Name)).OfType<NameValueAttribute>().ToArray();
    
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
    
            private static bool IsReadOnlyProperty(PropertyDescriptor propertyDescriptor)
            {
                var editableAttribute = propertyDescriptor.Attributes.OfType<EditableAttribute>().FirstOrDefault();
                return editableAttribute != null ? !editableAttribute.AllowEdit : false;
            }
        }
    }
