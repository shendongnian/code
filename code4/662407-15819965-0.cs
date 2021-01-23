       class Room
       {
         public Room(String name, Point location);
         public void Draw(Graphics g);
       }
       class Connection
       {
         public void Add(Point ptConnection);
         public void Add(Point[] ptConnection);
         // Draw will draw a straight line if only two points or will draw a bezier curve
         public void Draw(Graphics g);
       }
       class House // basically a graph
       {
         public void Add(Room room);
         public void AddRoomConnection(Room r1, Room r2, Connection connector);
         // draw, draw each room, then draw connections.
         public void Draw(Graphics g);
       }
       void Main()
       {
          House myHouse = new House();
          Room hall = new Room("Hall", new Point(120,10);
          Room bedroom1 = new Room("Bedroom1", Point(0, 80));
          Connection cnHallBedroom = new Connection();
          cn.Add(new Point());  // add two points to draw a line, 3 or more points to draw a curve.
          myHouse.AddRoomConnection(hall, bedroom1, cnHallBedroom);
       }
