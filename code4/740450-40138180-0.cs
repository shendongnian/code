    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    
    namespace AlyElHaddad.Stackoverflow
    {
        public class DataGridColumnCollection : ObservableCollection<DataGridColumn>
        {
            public DataGridColumnCollection()
                : base()
            { }
            public DataGridColumnCollection(IEnumerable<DataGridColumn> collection)
                : base(collection)
            { }
            public DataGridColumnCollection(List<DataGridColumn> list)
                : base(list)
            { }
        }
    }
