    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    namespace CheckboxList
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                //Create a viewmodel and add some data to it.
                var viewModel = new MyViewModel();
                viewModel.Items.Add(new Data() {Name = "lol", Type = "lol", Selected = true});
                viewModel.Items.Add(new Data() { Name = "lol", Type = "not_lol", Selected = true });
                viewModel.Items.Add(new Data() { Name = "not_lol", Type = "not_lol", Selected = true });
    
                //Set the window's datacontext to the ViewModel.  This will make binding work.
                this.DataContext = viewModel;
    
            }
        }
    
        //This is the ViewModel used to bind your data 
        public class MyViewModel 
        {
            //This could just be a List<Data> but ObservableCollection<T> will automatically
            //update your UI when items are added or removed from the collection.
            public ObservableCollection<Data> Items { get; set; }
    
            public MyViewModel()
            {
                Items = new ObservableCollection<Data>();
            }
        }
    
        //Just a sample class to hold the data for the grid.
        //This is the class that is contained in the ObservableColleciton in the ViewModel
        public class Data
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public bool Selected { get; set; }
        }
    
    
        //This is an example converter.  It looks to see if the element is set to "lol" 
        //If so, it returns Visibility.Collapsed.  Otherwise, it returns Visibility.Visible.
        public class LolToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null && value is string)
                {
                    var input = (string) value;
                    if (string.Equals(input, "lol", StringComparison.CurrentCultureIgnoreCase))
                    {
                        return Visibility.Collapsed;
                    }
                    else
                    {
                        return Visibility.Visible;
                    }
                }
    
                return Visibility.Visible;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
