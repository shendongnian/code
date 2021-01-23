    public class Driver
    {
        public int Id { get; set; }
        ...
        public virtual ICollection<Car> Drives  { get; set; }
    }
    
    public class Car
    {
        public int Id { get; set; }
        ...
        public virtual ICollection<Driver> DrivenBy { get; set; }
    }
