    public class Marker
    {
        public List<Vector> { get; set; }
    }
    public class Vector
    {
        public int[] Numbers { get; private set; }
        public Vector(params int[] numbers)
        {
            Numbers = numbers;
        }
    }
