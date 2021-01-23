    [DelimitedRecord("|")] 
    public class Order 
    { 
       // First field
       public int OrderID; 
       // Second field
       public string CustomerID; 
	   
       // Third field
       [FieldConverter(ConverterKind.Date, "ddMMyyyy")]   
       public DateTime OrderDate; 	 
    }
