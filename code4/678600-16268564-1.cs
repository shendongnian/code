    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
    namespace StackOverflowMultiButton
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                this.DataContext = new MainPage_ViewModel();
            } 
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
    public class MainPage_ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        bool _tbt1_isChecked = false;
        public bool tbt1_isChecked 
        {
            get {
                return this._tbt1_isChecked;
            }
            set {
                if (this._tbt1_isChecked == value)
                    return;
                this._tbt1_isChecked = value;
                OnPropertyChanged("tbt1_isChecked");
                OnPropertyChanged("CommonIsEnabled");
            }
        }
        bool _tbt2_isChecked = false;
        public bool tbt2_isChecked
        {
            get
            {
                return this._tbt2_isChecked;
            }
            set
            {
                if (this._tbt2_isChecked == value)
                    return;
                this._tbt2_isChecked = value;
                OnPropertyChanged("tbt2_isChecked");
                OnPropertyChanged("CommonIsEnabled");
            }
        }
        bool _tbt3_isChecked = false;
        public bool tbt3_isChecked
        {
            get
            {
                return this._tbt3_isChecked;
            }
            set
            {
                if (this._tbt3_isChecked == value)
                    return;
                this._tbt3_isChecked = value;
                OnPropertyChanged("tbt3_isChecked");
                OnPropertyChanged("CommonIsEnabled");
            }
        }
        bool _tbt4_isChecked = false;
        public bool tbt4_isChecked
        {
            get
            {
                return this._tbt4_isChecked;
            }
            set
            {
                if (this._tbt4_isChecked == value)
                    return;
                this._tbt4_isChecked = value;
                OnPropertyChanged("tbt4_isChecked");
                OnPropertyChanged("CommonIsEnabled");
            }
        }
        public bool CommonIsEnabled
        {
            get
            {
                return this._tbt1_isChecked ||
                    this._tbt2_isChecked ||
                    this._tbt3_isChecked ||
                    this._tbt4_isChecked;
                }
            }
        }
    }
