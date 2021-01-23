    using Microsoft.Phone.Controls;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
    namespace PhoneApp1
    {
        public class DisplayItems : INotifyPropertyChanged
        {
            private static readonly List<DisplayItem> _items = new List<DisplayItem>();
            public DisplayItems()
            {
                ResetList();
            }
            public List<DisplayItem> Items
            {
                get { return _items; }
            }
            public void ResetList()
            {
                _items.Clear();
                var lst = new List<DisplayItem>();
                var randomizer = new Random();
                for (var i = 0; i < 100; i++)
                {
                    lst.Add(new DisplayItem(randomizer.Next(0, 99).ToString(CultureInfo.InvariantCulture)));
                }
                _items.AddRange(lst);
                RaisePropertyChanged("Items");
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged(string property)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(property));
                }
            }
        }
        public class DisplayItem
        {
            public string Text { get; set; }
            public DisplayItem(string text)
            {
                Text = text;
            }
            public override string ToString()
            {
                return Text;
            }
        }
        public partial class Page1
        {
            public Page1()
            {
                InitializeComponent();
                DataContext = new DisplayItems();
            }
            private void Load_More(object sender, RoutedEventArgs e)
            {
                (DataContext as DisplayItems).ResetList();
            }
        }
    }
