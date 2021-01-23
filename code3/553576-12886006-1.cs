    using System;
    using System.ComponentModel;
    
    namespace CascadingDataGrids
    {
        public class Site : INotifyPropertyChanged
        {
            private int _id;
    
            /// <summary>
            /// Gets or sets the id.
            /// </summary>
            /// <value>
            /// The id.
            /// </value>
            public int Id
            {
                get { return _id; }
                set
                {
                    if (value != _id)
                    {
                        _id = value;
                        NotifyPropertyChanged("Id");
                    }
                }
            }
    
            private string _siteName;
    
            /// <summary>
            /// Gets or sets the name of the site.
            /// </summary>
            /// <value>
            /// The name of the site.
            /// </value>
            public string SiteName
            {
                get { return _siteName; }
                set
                {
                    {
                        if (value != _siteName)
                        {
                            _siteName = value;
                            NotifyPropertyChanged("SiteName");
                        }
                    }
                }
            }
            
            #region INotifyPropertyChanged
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
    
            #endregion
        }
    }
