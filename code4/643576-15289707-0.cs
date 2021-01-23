    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace WpfApplication2
    {
        /// <summary>
        /// Interaction logic for UserControl1.xaml
        /// </summary>
        public partial class UserControl1 : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
    
                // Set binding from code
                this.TBox.DataContext = this;
                this.TBox.SetBinding(TextBox.TextProperty, new Binding { Path = new PropertyPath("TBValue"), Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
            }
    
            public static readonly DependencyProperty TBValueProperty = DependencyProperty.Register("TBValue", typeof(string), typeof(UserControl1));
    
            public string TBValue
            {
                get { return this.GetValue(TBValueProperty) as string; }
                set { this.SetValue(TBValueProperty, value); }
            }
        }
    }
