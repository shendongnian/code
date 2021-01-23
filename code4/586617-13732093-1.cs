    public abstract class A
    {
        public int ColumnA { get; set; }
        public string ColumnB { get; set; }
        public int ColumnC { get; set; }
    }
    public class CustomerA_A : A
    {
        public string Location { get; set; }
    }
    public class CustomerB_A : A
    {
        public int DataCenterID { get; set; }
    }
