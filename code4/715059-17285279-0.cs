    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public List<Passanger> Passangers { get; set; }
    }
    public class Passanger
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
