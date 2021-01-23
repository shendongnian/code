    public class MyDataGridView : DataGridView, IMyInterface
    {
        public string LuName{get; set;}
        public MyDataGridView ()
        {
            this.RowTemplate = new MyDataGridViewRow();
        }
        //Soution is override the RowTemplate Property By MyDataGridViewRow
        public new MyDataGridViewRow RowTemplate
        {
            get
            {
                return (MyDataGridViewRow)base.RowTemplate;
            }
            set
            {
                base.RowTemplate = value;
            }
        }
        ...
    }
