    class Car {
        public Color { get; set; }
    }
    
    void Main()
    {
         List<Car> cars = GetList(); // not important
         var grouped = cars.GroupBy(c=>c.Color);
         var duplicates = cars.Where(g=>g.Count()>1);
         
    }
