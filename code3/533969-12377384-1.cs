    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    namespace WpfDataGridWithDataTable
    {
        public class Article
        {
            public Article()
            {
    
            }
            private int _modelNumber;
            public int ModelNumber
            {
                get { return _modelNumber; }
                set { _modelNumber = value; OnPropertyChanged("ModelNumber"); }
            }
    
            private string _modelName;
            public string ModelName
            {
                get { return _modelName; }
                set { _modelName = value; OnPropertyChanged("ModelName"); }
            }
    
            private decimal _unitCost;
            public decimal UnitCost
            {
                get { return _unitCost; }
                set { _unitCost = value; OnPropertyChanged("UnitCost"); }
            }
    
            private string _description;
            public string Description
            {
                get { return _description; }
                set { _description = value; OnPropertyChanged("Description"); }
            }
    
    
            #region INotifyPropertyChanged Membres
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
            #endregion
        }
        public class ListArticles : ObservableCollection<Article>
        {
            public Article a;
            public ListArticles()
            {
                a = new Article();
                this.Add(a);
    
            }
    
    
        }
    
    }
