    using System.Windows;
    using System.Windows.Controls;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Windows.Controls.Primitives;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                List<Make> cars = new List<Make>();
                cars.Add(new Make("Ford") { Models = new List<Model>() { new Model("F150"), new Model("Taurus"), new Model("Explorer") } });
                cars.Add(new Make("Honda") { Models = new List<Model>() { new Model("Accord"), new Model("Pilot"), new Model("Element") } });
                DataContext = cars; 
            }
    
            private void OnSelectedModelChanged(object sender, SelectionChangedEventArgs e)
            {
                Selector modelSelector = sender as Selector;
                Model selectedModel = modelSelector.SelectedItem as Model;
                Make selectedMake = modelSelector.DataContext as Make;
            }
        }
    
        public class Make
        {
            public Make(string name)
            {
                Name = name;
            }
    
            public string Name { get; private set; }
            public IEnumerable<Model> Models { get; set; }
        }
    
        public class Model
        {
            public Model(string name)
            {
                Name = name;
            }
            public string Name { get; private set; }
        }
    }
