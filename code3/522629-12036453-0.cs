    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Resources;
    
    namespace SilverlightTest
    {
        public partial class MainPage : UserControl, INotifyPropertyChanged
        {
            public MainPage()
            {
                InitializeComponent();
    
                using (var ms = new MemoryStream())
                {
                    StreamResourceInfo sr = Application.GetResourceStream(new Uri("SilverlightTest;component/Koala.jpg", UriKind.Relative));
                    sr.Stream.CopyTo(ms);
                    _photo = ms.ToArray();
                }
    
                this.DataContext = this;
            }
    
            private byte[] _photo;
            public byte[] Photo
            {
                get
                {
                    return _photo;
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string prop)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
                }
            }
        }
    }
