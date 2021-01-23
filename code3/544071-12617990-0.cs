    public class PaymentDetailsDataTable : DataTable
    {
        public PaymentDetailsDataTable()
        {
            Columns.Add("Col1", typeof(int));
            Columns.Add("Col2");
    
            Rows.Add(1, "Foo");
            Rows.Add(2, "Bar");
        }
    }
