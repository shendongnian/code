    using System.Windows;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System;
    using System.ComponentModel;
    using System.Windows.Data;
    using System.Globalization;
    namespace TestWPFApp
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new MainViewModel();
            }
        }
    
        public class WeightType : INotifyPropertyChanged
        {
            private int _id;
            public int Id
            {
                get { return _id; }
                set
                {
                    _id = value;
                    NotifyPropertyChanged("Id");
                }
            }
    
            private string _unitType;
            public string UnitType
            {
                get { return _unitType; }
                set
                {
                    _unitType = value;
                    NotifyPropertyChanged("UnitType");
                }
            }
    
            private float _factor;
            public float Factor
            {
                get { return _factor; }
                set
                {
                    _factor = value;
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            /// <summary>
            /// Call this to force the UI to refresh it's bindings.
            /// </summary>
            /// <param name="name"></param>
            public void NotifyPropertyChanged(String name)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
        }
    
        public class MainViewModel : INotifyPropertyChanged
        {
            private List<WeightType> _weightTypeList = new List<WeightType>();
            public List<WeightType> WeightTypeList
            {
                get { return _weightTypeList; }
                set
                {
                    _weightTypeList = value;
                }
            }
            private double _currentWeight;
            public double CurrentWeight
            {
    
                get { return _currentWeight; }
                set
                {
                    _currentWeight = value;
                    NotifyPropertyChanged("CurrentWeight");
                }
            }
    
            private WeightType _selectedWeightType;
            public WeightType SelectedWeightType
            {
                get { return _selectedWeightType; }
                set
                {
                    var previousType = _selectedWeightType;
                    _selectedWeightType = value;
                    NotifyPropertyChanged("SelectedWeightType");
                    if(previousType != null)
                        CurrentWeight = (CurrentWeight / previousType.Factor) * _selectedWeightType.Factor;
                }
            }
    
            public MainViewModel()
            {
                WeightTypeList.Add(new WeightType() { Id = 1, UnitType = "Lbs", Factor = 1f });
                WeightTypeList.Add(new WeightType() { Id = 2, UnitType = "Kg",Factor = 0.453592f });
                WeightTypeList.Add(new WeightType() { Id = 1, UnitType = "St", Factor = 0.0714286f });
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(String name)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
        }
    
        public class BoolToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType,
                object parameter, CultureInfo culture)
            {
                return null;
            }
    
            public object ConvertBack(object value, Type targetType,
                object parameter, CultureInfo culture)
            {
                return null;
            }
        }
    
    }
