    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.ComponentModel;
    namespace WpfApplication10
    {
      public partial class MainWindow : Window, INotifyPropertyChanged
      {
       #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        private bool _HasChanges = false;
        public bool HasChanges
        {
            get { return this._HasChanges; }
            set
            {
                this._HasChanges = value;                
                NotifyPropertyChange("HasChanges");
            }
        } 
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String[] list = { "1", "2", "3", "4" };
            this.MainGrid.ItemsSource = list;            
        }
      }
    }
