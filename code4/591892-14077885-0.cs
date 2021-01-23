    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace WpfApplication
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var records = new RecordCollection(new Property("Name"), new Property("Surname"));
    
                for (int i = 0; i < 1000; ++i)
                    records.Add(new Record()
                    {
                        { "Name", "John " + i },
                        { "Surname", "Doe " + i }
                    });
    
                this.dataGrid.ItemsSource = records;
            }
    
            private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {
                var property = e.PropertyDescriptor as Property;
                if (property != null)
                {
                    var binding = new Binding() { Path = new PropertyPath(property), Mode = property.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
                    var dataGridBoundColumn = e.Column as DataGridBoundColumn;
                    if (dataGridBoundColumn != null)
                        dataGridBoundColumn.Binding = binding;
                    else
                    {
                        var dataGridComboBoxColumn = e.Column as DataGridComboBoxColumn;
                        if (dataGridComboBoxColumn != null)
                            dataGridComboBoxColumn.SelectedItemBinding = binding;
                    }
                }
            }
        }
    
        public sealed class Record : INotifyPropertyChanged, IEnumerable
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private readonly IDictionary<string, object> values = new SortedList<string, object>(StringComparer.Ordinal);
    
            private void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                    handler(this, e);
            }
    
            public object GetValue(string name)
            {
                object value;
                return this.values.TryGetValue(name, out value) ? value : null;
            }
    
            public void SetValue(string name, object value)
            {
                if (!object.Equals(this.GetValue(name), value))
                {
                    this.values[name] = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs(name));
                }
            }
    
            public void Add(string name, object value)
            {
                this.values[name] = value;
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.values.GetEnumerator();
            }
        }
    
        public sealed class Property : PropertyDescriptor
        {
            private readonly Type propertyType;
            private readonly bool isReadOnly;
    
            public Property(string name)
                : this(name, typeof(string))
            {
            }
    
            public Property(string name, Type propertyType)
                : this(name, propertyType, false)
            {
            }
    
            public Property(string name, Type propertyType, bool isReadOnly, params Attribute[] attributes)
                : base(name, attributes)
            {
                this.propertyType = propertyType;
                this.isReadOnly = isReadOnly;
            }
    
            public override Type ComponentType
            {
                get { return typeof(Record); }
            }
    
            public override Type PropertyType
            {
                get { return this.propertyType; }
            }
    
            public override bool IsReadOnly
            {
                get { return this.isReadOnly; }
            }
    
            public override object GetValue(object component)
            {
                var record = component as Record;
                return record != null ? record.GetValue(this.Name) : null;
            }
    
            public override void SetValue(object component, object value)
            {
                var record = component as Record;
                if (record != null)
                    record.SetValue(this.Name, value);
            }
    
            public override bool CanResetValue(object component)
            {
                throw new NotSupportedException();
            }
    
            public override void ResetValue(object component)
            {
                throw new NotSupportedException();
            }
    
            public override bool ShouldSerializeValue(object component)
            {
                throw new NotSupportedException();
            }
        }
    
        public sealed class RecordCollection : ObservableCollection<Record>, ITypedList
        {
            private readonly PropertyDescriptorCollection properties;
    
            public RecordCollection(params Property[] properties)
            {
                this.properties = new PropertyDescriptorCollection(properties);
            }
    
            PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
            {
                return this.properties;
            }
    
            string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
            {
                return string.Empty;
            }
        }
    }
    <Window x:Class="WpfApplication.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:local="clr-namespace:WpfApplication">
        <DataGrid x:Name="dataGrid" AutoGeneratingColumn="OnAutoGeneratingColumn"/>
    </Window>
