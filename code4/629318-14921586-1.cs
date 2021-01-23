    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.ComponentModel;
    
    namespace WpfApplication5
    {
        public partial class Window3 : Window
        {
            public Window3()
            {
                InitializeComponent();
    
                DataContext = new ObservableCollection<ItemBase>
                    {
                        new Item1() {MyText1 = "This is MyText1 inside an Item1"},
                        new Item2() {MyText2 = "This is MyText2 inside an Item2"},
                        new Item3() {MyText3 = "This is MyText3 inside an Item3", MyBool = true}
                    };
            }
        }
    
        public class ItemBase: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void NotifyPropertyChange(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public class Item1: ItemBase
        {
            private string _myText1;
            public string MyText1
            {
                get { return _myText1; }
                set
                {
                    _myText1 = value;
                    NotifyPropertyChange("MyText1");
                }
            }
        }
    
        public class Item2: ItemBase
        {
            private string _myText2;
            public string MyText2
            {
                get { return _myText2; }
                set
                {
                    _myText2 = value;
                    NotifyPropertyChange("MyText2");
                }
            }
    
            private ObservableCollection<string> _options;
            public ObservableCollection<string> Options
            {
                get { return _options ?? (_options = new ObservableCollection<string>()); }
            }
    
            public Item2()
            {
                Options.Add("Option1");
                Options.Add("Option2");
                Options.Add("Option3");
                Options.Add("Option4");
            }
        }
    
        public class Item3: ItemBase
        {
            private string _myText3;
            public string MyText3
            {
                get { return _myText3; }
                set
                {
                    _myText3 = value;
                    NotifyPropertyChange("MyText3");
                }
            }
    
            private bool _myBool;
            public bool MyBool
            {
                get { return _myBool; }
                set
                {
                    _myBool = value;
                    NotifyPropertyChange("MyBool");
                }
            }
        }
    }
