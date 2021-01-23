    public class SDataGrid : DataGrid
    {
        static SDataGrid()
        {
            ItemsControl.ItemsSourceProperty.OverrideMetadata(typeof(SDataGrid), new FrameworkPropertyMetadata((PropertyChangedCallback)null, (CoerceValueCallback)null));
        }
    }
