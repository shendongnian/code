    class MovementView {
       private Movement movement;
       public MovementView(Movement m) { movement = m; }
       public string Name { get { return movement.Name; } }
       // etc..
       public string Location1Name { get { return movement.Locations[0].Name; } }
       // etc..
    }
