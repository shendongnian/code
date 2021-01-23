    using System;
    using System.ComponentModel;
    
    namespace CascadingDataGrids
    {
        public class Company : INotifyPropertyChanged
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
    
            private string _companyName;
    
            /// <summary>
            /// Gets or sets the name of the company.
            /// </summary>
            /// <value>
            /// The name of the company.
            /// </value>
            public string CompanyName
            {
                get { return _companyName; }
                set
                {
                    {
                        if (value != _companyName)
                        {
                            _companyName = value;
                            NotifyPropertyChanged("CompanyName");
                        }
                    }
                }
            }
    
            private int _siteId;
    
            /// <summary>
            /// Gets or sets the site id.
            /// </summary>
            /// <value>
            /// The site id.
            /// </value>
            public int SiteId
            {
                get { return _siteId; }
                set
                {
                    if (value != _siteId)
                    {
                        _siteId = value;
                        NotifyPropertyChanged("SiteId");
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
