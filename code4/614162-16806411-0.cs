    public class MyGrid : DataGridView {
        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            MyComparer YourComparer = null;
            this.Sort(YourComparer);
        }
    }
