    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    
    namespace CascadingDataGrids
    {
        public class DemoViewModel : INotifyPropertyChanged
        {
            #region Properties
    
            private ObservableCollection<Company> _companies;
    
            /// <summary>
            /// Gets or sets the companies.
            /// </summary>
            /// <value>
            /// The companies.
            /// </value>
            public ObservableCollection<Company> Companies
            {
                get { return _companies; }
                set
                {
                    if (value != _companies)
                    {
                        _companies = value;
                        NotifyPropertyChanged("Companies");
                    }
                }
            }
    
            private Company _selectedCompany;
    
            /// <summary>
            /// Gets or sets the selected company.
            /// </summary>
            /// <value>
            /// The selected company.
            /// </value>
            public Company SelectedCompany
            {
                get { return _selectedCompany; }
                set
                {
                    if (value != _selectedCompany)
                    {
                        _selectedCompany = value;
                        NotifyPropertyChanged("SelectedCompany");
    
                        // Set Site
                        var currentSite =
                            Sites.FirstOrDefault(x => x.Id == SelectedCompany.SiteId);
    
                        // Evaluate
                        if (currentSite != null)
                        {
                            SelectedSite = currentSite;
                        }
                    }
                }
            }
    
            private ObservableCollection<Site> _sites;
    
            /// <summary>
            /// Gets or sets the sites.
            /// </summary>
            /// <value>
            /// The sites.
            /// </value>
            public ObservableCollection<Site> Sites
            {
                get { return _sites; }
                set
                {
                    if (value != _sites)
                    {
                        _sites = value;
                        NotifyPropertyChanged("Sites");
                    }
                }
            }
    
            private Site _selectedSite;
    
            /// <summary>
            /// Gets or sets the selected site.
            /// </summary>
            /// <value>
            /// The selected site.
            /// </value>
            public Site SelectedSite
            {
                get { return _selectedSite; }
                set
                {
                    if (value != _selectedSite)
                    {
                        _selectedSite = value;
                        NotifyPropertyChanged("SelectedSite");
                    }
                }
            }
    
            #endregion
    
            #region Constructors
    
            /// <summary>
            /// Initializes a new instance of the <see cref="DemoViewModel"/> class.
            /// </summary>
            public DemoViewModel()
            {
                // New instances
                Companies = new ObservableCollection<Company>();
                Sites = new ObservableCollection<Site>();
    
                // Build
                BuildCompanies();
                BuildSites();
            }
    
            #endregion
    
            #region Members
    
            /// <summary>
            /// Builds the companies.
            /// </summary>
            private void BuildCompanies()
            {
                // Set companies
                Companies = new ObservableCollection<Company>
                {
                    new Company { Id = 1, CompanyName = "Microsoft", SiteId = 1 },
                    new Company { Id = 2, CompanyName = "Google", SiteId = 3 },
                    new Company { Id = 3, CompanyName = "Amazon", SiteId = 2 },
                };
    
                // Set selected to first value
                SelectedCompany = Companies.FirstOrDefault();
            }
    
            /// <summary>
            /// Builds the sites.
            /// </summary>
            private void BuildSites()
            {
                // Set sites
                Sites = new ObservableCollection<Site>
                {
                    new Site { Id = 1, SiteName = "Redmond, WA" },
                    new Site { Id = 2, SiteName = "Seattle, WA" },
                    new Site { Id = 3, SiteName = "Mountain View, CA" }
                };
    
                // Set selected to first value
                SelectedSite = Sites.FirstOrDefault();
            }
    
            #endregion
    
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
