    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Phone.Controls;
    namespace WP7Sandbox
    {
        public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            private bool IsLoaded;
            private bool IgnoreSelectionChanged;
            public ObservableCollection<string> ListPickerCollection { get; private set; }
            private bool _ToggleSwitchValue;
            public bool ToggleSwitchValue
            {
                get
                {
                     return _ToggleSwitchValue;
                }
                set
                {
                    _ToggleSwitchValue = value;
                    OnPropertyChanged("ToggleSwitchValue");
                }
            }
            private int _ListPickerSelectedIndex;
            public int ListPickerSelectedIndex
            {
                get
                {
                    return _ListPickerSelectedIndex;
                } 
                set
                {
                    _ListPickerSelectedIndex = value;
                    OnPropertyChanged("ListPickerSelectedIndex");
                }
            }
            public MainPage()
            {
                InitializeComponent();
                ListPickerCollection = new ObservableCollection<string>()
                {
                    "Red",
                    "Blue",
                    "Green",
                    "Custom…"
                };
            }
            private void PhoneApplicationPageLoaded(object sender, RoutedEventArgs e)
            {
                IsLoaded = true;
            }
            private void ListPickerSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (IsLoaded && !IgnoreSelectionChanged)
                {
                }
                IgnoreSelectionChanged = false;
            }
            private void ButtonClick(object sender, RoutedEventArgs e)
            {
                // I want to ignore this SelectionChanged Event
                IgnoreSelectionChanged = true;
                ChangeListPickerSelectedIndex();
            }
            private void Button2Click(object sender, RoutedEventArgs e)
            {
                // I want to trigger this SelectionChanged Event
                IgnoreSelectionChanged = false; // Not needed just showing you
                ChangeListPickerSelectedIndex();
            }
            private void ChangeListPickerSelectedIndex()
            {
                if (ListPickerSelectedIndex - 1 < 0)
                    ListPickerSelectedIndex = ListPickerCollection.Count - 1;
                else
                    ListPickerSelectedIndex--;
            }
        }
    }
   
