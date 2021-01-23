    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using InduraClientCommon.MVVM;
    using System.Collections.ObjectModel;
    
    namespace WpfApplication4
    {
        public partial class Window9 : Window
        {
            public Window9()
            {
                InitializeComponent();
    
                var vm = new ColumnListViewModel();
                vm.Columns.Add(new ColumnViewModel() { IsPrimaryKey = true, Name = "Customer ID", SortOrder = SortOrder.Ascending });
                vm.Columns.Add(new ColumnViewModel() {Name = "Customer Name", SortOrder = SortOrder.Descending});
                vm.Columns.Add(new ColumnViewModel() {Name = "Customer Age", SortOrder = SortOrder.Unsorted});
    
                DataContext = vm;
            }
        }
    }
