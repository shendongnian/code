    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    namespace DataGridSpike
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private List<Option> _unsortedOptions;
            private ObservableCollection<OptionRow> _groupedOptions;
    
            public ObservableCollection<OptionRow> GroupedOptions
            {
                get { return _groupedOptions; }
                set { _groupedOptions = value; }
            }
    
            public MainWindow()
            {
                var rnd=new Random();
                InitializeComponent();
    
                //Generate some random data
                _unsortedOptions=new List<Option>();
                for(int element=0;element<50;element++)
                {
                    double column=rnd.Next(-2,3);
                    int row=rnd.Next(0,9);
    
                    _unsortedOptions.Add(new Option { ColumnDefiningValue = column, RowDefiningValue = row });
                }
    
                //Prepare the data for the DataGrid
                //group and sort
                var rows = from option in _unsortedOptions
                           orderby option.ColumnDefiningValue
                           group option by option.RowDefiningValue into optionRow
                           orderby optionRow.Key ascending
                           select optionRow;
    
                //convert to ObservableCollection
                _groupedOptions = new ObservableCollection<OptionRow>();
                foreach (var groupedOptionRow in rows)
                {
                    var groupedRow = new OptionRow(groupedOptionRow);
                    _groupedOptions.Add(groupedRow);
                }
    
                //bind the ObservableCollection to the DataGrid
                DataContext = GroupedOptions;
            }
        }
    
        public class OptionRow
        {
            private List<Option> _options;
    
            public OptionRow(IEnumerable<Option> options)
            {
                _options = options.ToList();
            }
    
            public Option Minus2
            {
                get
                {
                    return (from option in _options
                           where option.ColumnDefiningValue == -2
                           select option).FirstOrDefault();
                }
            }
            public Option Minus1
            {
                get
                {
                    return (from option in _options
                            where option.ColumnDefiningValue == -1
                            select option).FirstOrDefault();
                }
            }
            public Option Zero
            {
                get
                {
                    return (from option in _options
                            where option.ColumnDefiningValue == 0
                            select option).FirstOrDefault();
                }
            }
            public Option Plus1
            {
                get
                {
                    return (from option in _options
                            where option.ColumnDefiningValue == 1
                            select option).FirstOrDefault();
                }
            }
            public Option Plus2
            {
                get
                {
                    return (from option in _options
                            where option.ColumnDefiningValue == 2
                            select option).FirstOrDefault();
                }
            }
        }
    
        public class Option:INotifyPropertyChanged
        {
    
            public override string ToString()
            {
                return string.Format("{0}-{1}", RowDefiningValue.ToString(),ColumnDefiningValue.ToString());
            }
    
            private double _columnDefiningValue;
            public double ColumnDefiningValue
            {
                get{return _columnDefiningValue;}
                set{_columnDefiningValue = value;
                    OnPropertyChanged("ColumndDefiningValue");
                }
            }
    
            private int _rowDefiningValue;
            public int RowDefiningValue
            {
                get{return _rowDefiningValue;}
                set{_rowDefiningValue = value;
                    OnPropertyChanged("RowDefiningValue");
                }
            }
            
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged!=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
