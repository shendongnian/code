    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Data;
    
        namespace BindingSample
        {
            public class ViewModel
            {
                private string[] _items = new[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
        
                public ViewModel()
                {
                    List1 = new ListCollectionView(_items);
                    List2 = new ListCollectionView(_items);
                    List3 = new ListCollectionView(_items);
        
                    List1.CurrentChanged += (sender, args) => SyncSelections(List1);
                    List2.CurrentChanged += (sender, args) => SyncSelections(List2);
                    List3.CurrentChanged += (sender, args) => SyncSelections(List3);
                }
        
                public ListCollectionView List1 { get; set; }
        
                public ListCollectionView List2 { get; set; }
        
                public ListCollectionView List3 { get; set; }
        
                private void SyncSelections(ListCollectionView activeSelection)
                {
                    foreach (ListCollectionView view in new[] { List1, List2, List3 })
                    {
                        if (view != activeSelection && view.CurrentItem == activeSelection.CurrentItem)
                            view.MoveCurrentTo(null);
                    }
                }
            }
        }
