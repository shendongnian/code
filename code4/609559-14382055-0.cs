    class Car : Vehicle
    {
        ...
    
        List<Car> CarList;
        public Car()
        {
            CarList = new List<Car>  // do this in each constructor
            ...
        }
        
        ...
    
    
        public void button1_Click(object sender, EventArgs e)
        {
            Car car = new Car();
    
            ...
    
            CarList.Add(car);
        }
    }
 
