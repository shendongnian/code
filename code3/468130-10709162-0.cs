    [MetadataTypeAttribute(typeof(SalesOrderLines.SalesOrderLinesMetadata))]
    public partial class SalesOrderLines
    {
        internal sealed class SalesOrderLinesMetadata
        {
            private SalesOrderLinesMetadata()
            {
            }
            public DateTime DateStamp { get; set; }
            public string OrderNumber { get; set; }
            [Key]
            public int SalesOrderLineID { get; set; }
            public string SerialNumber { get; set; }
            public string StockCode { get; set; }
        }
    }
