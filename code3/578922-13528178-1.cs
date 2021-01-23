    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Windows;
    using System.Windows.Media;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
            public ObservableCollection<TestObject> Items
            {
                get { return (ObservableCollection<TestObject>)GetValue(ItemsProperty); }
                set { SetValue(ItemsProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ItemsProperty =
                DependencyProperty.Register("Items", typeof(ObservableCollection<TestObject>), typeof(MainWindow), new PropertyMetadata(null));
    
    
    
            public MainWindow()
            {
                InitializeComponent();
                Items = new ObservableCollection<TestObject>();
                Items.Add(new TestObject() { Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." });
                Items.Add(new TestObject() { Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." });
            }
        }
    
        public class TestObject : DependencyObject
        {
    
    
            public string Description
            {
                get { return (string)GetValue(DescriptionProperty); }
                set { SetValue(DescriptionProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty DescriptionProperty =
                DependencyProperty.Register("Description", typeof(string), typeof(TestObject), new PropertyMetadata(null));
    
    
        }
    }
