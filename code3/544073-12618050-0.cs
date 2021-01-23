    public class PaymentDetailsDataTable : DataTable
    {
        public PaymentDetailsDataTable()
        {
            DataColumn col1 = new DataColumn("col1");
            DataColumn col2 = new DataColumn("col2");
            DataColumn col3 = new DataColumn("col3");
            DataColumn col4 = new DataColumn("col4");
            DataColumn col5 = new DataColumn("col5");
            DataColumn col6 = new DataColumn("col6");
            DataColumn col7 = new DataColumn("col7");
            DataColumn col8 = new DataColumn("col8");
            DataColumn col9 = new DataColumn("col9");
            col1.DataType = System.Type.GetType("System.Int32");
            col2.DataType = System.Type.GetType("System.String");
            col3.DataType = System.Type.GetType("System.String");
            col4.DataType = System.Type.GetType("System.String");
            col5.DataType = System.Type.GetType("System.String");
            col6.DataType = System.Type.GetType("System.String");
            col7.DataType = System.Type.GetType("System.String");
            col8.DataType = System.Type.GetType("System.Double");
            col9.DataType = System.Type.GetType("System.String");
            this.Columns.Add(col1);
            this.Columns.Add(col2);
            this.Columns.Add(col3);
            this.Columns.Add(col4);
            this.Columns.Add(col5);
            this.Columns.Add(col6);
            this.Columns.Add(col7);
            this.Columns.Add(col8);
            this.Columns.Add(col9);
            this.Rows.Add();
        }
    }
