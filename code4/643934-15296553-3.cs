    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication1
    {
        public class MyClass
        {
            public string Name { get; set; }
        }
    
        public partial class MainWindow : Window
        {
            public ObservableCollection<MyClass> Items
            {
                get { return (ObservableCollection<MyClass>)GetValue(ItemsProperty); }
                set { SetValue(ItemsProperty, value); }
            }
            public static readonly DependencyProperty ItemsProperty =
                DependencyProperty.Register("Items", typeof(ObservableCollection<MyClass>), typeof(MainWindow), new PropertyMetadata(null));
    
            public MainWindow()
            {
                InitializeComponent();
    
                Items = new ObservableCollection<MyClass>();
                Items.Add(new MyClass() { Name = "Item1" });
                Items.Add(new MyClass() { Name = "Item2" });
                Items.Add(new MyClass() { Name = "Item3" });
                Items.Add(new MyClass() { Name = "Item4" });
                Items.Add(new MyClass() { Name = "Item5" });
            }
        }
    }
