    public class Dinosaur
            {
                public string Specie { get; set; }
                public int Age { get; set; }
                public List<System.Windows.Point> Location { get; set; } // this shouldn't be static
    
                // Constructor
                public Dinosaur()
                {
    
                }
            }
        public static List<Dinosaur> Dinosaurs = new List<Dinosaur>(); // your list of dinosaurs somewhere
        List<System.Windows.Point> yourListOfPoints = new List<System.Windows.Point>(); // create a new list of points to add
        yourListOfPoints.Add(new Point { X = pixelMousePositionX, Y = oldLocation.Y }); // add some points to list
        Dinosaurs.Last().Location.AddRange(yourListOfPoints); // select last dinosaur from list and assign your list of points to it's location property
