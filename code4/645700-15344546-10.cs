    using System.Collections.Generic;
    using System.Windows;
    using System.ComponentModel;
    using System;
    
    namespace WpfApplication4
    {
        public partial class Window17 : Window
        {
            public List<SudokuViewModel> Board { get; set; } 
    
            public Window17()
            {
                InitializeComponent();
    
                var random = new Random();
    
                Board = new List<SudokuViewModel>();
    
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Board.Add(new SudokuViewModel()
                                      {
                                          Row = i, Column = j,
                                          Value = random.Next(1,20),
                                          OnValueChanged = OnItemValueChanged
                                      });
                    }
                }
    
                DataContext = Board;
            }
    
            private void OnItemValueChanged(SudokuViewModel vm)
            {
                MessageBox.Show("Value Changed!\n" + "Row: " + vm.Row + "\nColumn: " + vm.Column + "\nValue: " + vm.Value);
            }
        }
    
        public class SudokuViewModel:INotifyPropertyChanged
        {
            public int Row { get; set; }
    
            public int Column { get; set; }
    
            private int _value;
            public int Value
            {
                get { return _value; }
                set
                {
                    _value = value;
                    NotifyPropertyChange("Value");
    
                    if (OnValueChanged != null)
                        OnValueChanged(this);
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyPropertyChange(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));        
            }
    
            public Action<SudokuViewModel> OnValueChanged { get; set; }
    
        }
    }
