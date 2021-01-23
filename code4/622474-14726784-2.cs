    public class Car : IComparable<Car> 
    { 
        public string Number { get; set; } 
    
        public int CompareTo(Car obj) 
        { 
            return obj.Number.CompareTo(Number); 
        } 
    }
