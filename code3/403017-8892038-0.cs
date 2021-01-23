    public class MyOrderObject
    {
       public int OrderID { get; set; }
       public string OrderDescription { get; set; }
       public int? EmployeeID { get; set; }
       public ICollection<MyProductObject> ProductsList { get; set; }
       ...other fields
    }
