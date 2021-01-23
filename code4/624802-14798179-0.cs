    interface IView
    {
       void SaveView(Control control );
    }
    public class GridViewHelper : IView
    {
        public void SaveView(Control control)
        {
            var view = (DataGridView)control;
            foreach (DataGridViewColumn col in view.Columns)
            {
                // save properties
            }
        }
    }
    public class ListViewHelper : IView
    {
        
        public void SaveView(Control control)
        {
            var view = (ListView)control;
            foreach (ColumnHeader  col in view.Columns)
            {
                // save properties
            }
        }
    }
