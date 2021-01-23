    namespace SilverlightPivotViewer.Extensions
    {
        #region Using directives
        using System.Collections.Generic;
        using System.Linq;
        using System.Windows.Controls.Pivot;
        #endregion
        public static class ICollectionPivotViewerItemExtensions
        {
            #region Public Methods and Operators
            public static void KeepIntersection(
                this ICollection<PivotViewerItem> currentItems, CxmlCollectionSource newItems)
            {
                RemoveCurrentUniqueItems(currentItems, newItems);
                AddNewUniqueItems(currentItems, newItems);
            }
            #endregion
            #region Methods
            private static void AddNewUniqueItems(ICollection<PivotViewerItem> currentItems, CxmlCollectionSource newItems)
            {
                IEnumerable<PivotViewerItem> onlyInNewCollection =
                    newItems.Items.Where(pivotViewerItem => currentItems.All(i => i.Id != pivotViewerItem.Id));
                foreach (var pivotViewerItem in onlyInNewCollection)
                {
                    currentItems.Add(pivotViewerItem);
                }
            }
            private static void RemoveCurrentUniqueItems(
                ICollection<PivotViewerItem> currentItems, CxmlCollectionSource newItems)
            {
                IEnumerable<PivotViewerItem> onlyInCurrentCollection =
                    currentItems.Where(pivotViewerItem => newItems.Items.All(i => i.Id != pivotViewerItem.Id));
                // Need to produce a list, otherwise it will crash (concurrent looping and editing the IEnumerable, or something related)
                var onlyInCurrentCollectionList = onlyInCurrentCollection.ToList();
                foreach (var pivotViewerItem in onlyInCurrentCollectionList)
                {
                    currentItems.Remove(pivotViewerItem);
                }
            }
            #endregion
        }
    }
