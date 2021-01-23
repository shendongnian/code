    class Car
    {
       // Keep a reference to the game inside the car class.
       Game game;
    
       public Car (Game game)
       { 
          this.game = game;
       }
       public void Update(.....
       { 
           // You can access the client bounds here.
           // the best thing about this method is that
           // if the bounds ever changes, you don't have
           // to notify the car, it always has the correct
           // values.
       }
    }
