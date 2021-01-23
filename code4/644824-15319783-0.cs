    [DelimitedRecord("|")]
    public class Orders
    {
       public int OrderID;
    
       public string CustomerID;
       [FieldConverter(ConverterKind.Date, "ddMMyyyy")]   public DateTime OrderDate;
    
       public decimal Freight;
    }
