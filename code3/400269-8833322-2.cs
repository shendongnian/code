    [DelimitedRecord("|")] 
    public class Order 
    { 
       // Third field
       [FieldOrder(3)]
       public int OrderID; 
       // Second field
       [FieldOrder(2)]
       public string CustomerID; 
	   
       // First field
       [FieldOrder(1)]
       [FieldConverter(ConverterKind.Date, "ddMMyyyy")]   
       public DateTime OrderDate; 	 
    }
