    class Building
    {
       public List<Elevator> Elevators { get; set; }
    
       public Building(params Elevator[] elevators)
       {
           Elevators = elevators.ToList();
       }
    }
