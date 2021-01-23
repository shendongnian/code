    public class RowStyle : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            var dgRow = item as DataGridRow;
            int val = int.Parse(dgRow.Row[0].ToString());
            if ( data.IsArchived(val) )
            {
                return Mystyle;
            }
            return base.SelectStyle(item, container);
        }
        // style will be defined in xaml
        public Style Mystyle
        {
            get;
            set;
        }
    }
