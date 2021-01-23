    public class MyDataGridView : DataGridView
    {
        protected override viod OnCellContentDoubleClick(
	DataGridViewCellEventArgs e)
        {
            // by having no code here and not 
            // calling base.OnCellContentDoubleClick(e);
            // you prevent the event being raised
        }
    }
