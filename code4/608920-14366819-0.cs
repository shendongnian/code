    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PB.Base;
    namespace DynTabItems
    {
        public class MainWindowViewModel
        {
            public MainWindowViewModel()
            {
                AddItemCommand = new DelegateCommand(AddItem, CanAddItem);
                RemoveItemCommand = new DelegateCommand(RemoveItem, CanRemoveItem);
            }
            public DelegateCommand AddItemCommand { private set; get; }
            public DelegateCommand RemoveItemCommand { private set; get; }
            ObservableCollection<MyModel> _yourBehaviorClass = new ObservableCollection<MyModel>();
            MyModel _selectetItem;
            public MyModel SelectetItem
            {
                get { return _selectetItem; }
                set { _selectetItem = value; }
            }
            public ObservableCollection<MyModel> YourBehaviorClass
            {
                get { return _yourBehaviorClass; }
                set { _yourBehaviorClass = value; }
            }
            private void AddItem(object obj)
            {
                YourBehaviorClass.Add(new MyModel());
            }
            private bool CanRemoveItem(object obj)
            {
                return SelectetItem != null;
            }
            private bool CanAddItem(object obj)
            {
                return true;
            }
            private void RemoveItem(object obj)
            {
                YourBehaviorClass.Remove(SelectetItem);
            }
        }
    }
