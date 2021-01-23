    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            private DataTable _myDataTable;
            public DataTable MyDataTable { 
                get 
                {
                    return _myDataTable;
                } 
                set
                { 
                    _myDataTable = value;
                } 
            }
        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int k=0; k < 10; k++) 
            {
                MyDataTable.Columns.Add();   
            }
            for (int j=0; j < 10; j++)
            {       
                TableRow r = new TableRow();
                System.Data.DataRow row = MyDataTable.NewRow();
                for (int i = 0; i < caract+1; i++)
                {
                    row[i]=(datar[j,i].ToString());
                }
                    MyDataTable.Rows.Add(row);
                    Table1.Rows.Add(r);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(MyDataTable !=null || MyDataTable.Rows.Count == 0)
            {
                string name="productos";
                Label2.Text="it has data";
            }
            else
            {
                Label2.Text="NO data"; 
            }
        }
    }
}
