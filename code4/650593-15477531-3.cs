    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Data;
    using System.ComponentModel;
    
    namespace gregory.bmclub
    {
        class EmployeeListViewModel : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void OnPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
            #endregion
    
            public EmployeeListViewModel()//modified to public
            {
                EmployeeList = new ObservableCollection<EmployeeViewModel>(GetEmployees());
                this._view = new ListCollectionView(this.employeeList);
            }
            #region nonModifiedCode
            private ListCollectionView _employeeCol;
            public ICollectionView EmployeeCollection
            {
                get { return this._employeeCol; }
            }
    
            private ObservableCollection<EmployeeViewModel> employeeList;
            public ObservableCollection<EmployeeViewModel> EmployeeList
            {
                get { return employeeList; }
                set
                {
                    employeeList = value;
                    OnPropertyChanged("EmployeeList");
                }
            }
    
            private ListCollectionView _view;
            public ICollectionView View
            {
                get { return this._view; }
            }
    
            private string _TextSearch;
            public string TextSearch
            {
                get { return _TextSearch; }
                set
                {
                    _TextSearch = value;
                    OnPropertyChanged("TextSearch");
    
                    if (String.IsNullOrEmpty(value))
                        View.Filter = null;
                    else
                        View.Filter = new Predicate<object>(o => ((EmployeeViewModel)o).FirstName == value);
                }
            }
            #endregion
    
            //created for testing
            private List<EmployeeViewModel> GetEmployees()
            {
                var mylist = new List<EmployeeViewModel>();
                mylist.Add(new EmployeeViewModel() { FirstName = "nummer1" });
                mylist.Add(new EmployeeViewModel() { FirstName = "nummer2" });
    
                return mylist;
            }
        }
    }
