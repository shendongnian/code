    public class DataGridICollectionViewSortMerkerBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Sorting += AssociatedObjectSorting;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Sorting -= AssociatedObjectSorting;
        }
        void AssociatedObjectSorting(object sender, DataGridSortingEventArgs e)
        {
            var view = AssociatedObject.ItemsSource as ICollectionView;
            var propertyname = e.Column.SortMemberPath;
            e.Column.SortDirection = this.GetSortArrowForColumn(e.Column);
           
            if (view == null)
                return;
            view.SortDescriptions.Clear();            
            var sort = new SortDescription(propertyname, (ListSortDirection)e.Column.SortDirection);
            view.SortDescriptions.Add(sort);
            
            e.Handled = true;
        }
        private ListSortDirection GetSortArrowForColumn(DataGridColumn col)
        {
            if (col.SortDirection == null)
            {
               return ListSortDirection.Ascending;
            }
            else
            {
                return col.SortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            }
        }
       }
