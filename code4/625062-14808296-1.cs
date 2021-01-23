    public class VariableGrid : GridView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            ITileItem tile = item as ITileItem;
            if (tile != null)
            {
                GridViewItem griditem = element as GridViewItem;
                if (griditem != null)
                {
                    VariableSizedWrapGrid.SetColumnSpan(griditem, tile.ColumnSpan);
                    VariableSizedWrapGrid.SetRowSpan(griditem, tile.RowSpan);
                }
            }
            base.PrepareContainerForItemOverride(element, item);
        }
    }
