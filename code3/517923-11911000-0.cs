    public class Horse
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Breed Breed { get; set; }
        public DateTime WhenBorn { get; set; }
        // etc...
    }
    public class Race
    {
        public string Venue { get; set; }
        public DateTime WhenStarted { get; set; }
        public DateTime WhenFinished { get; set; }
        // etc...
    }
    public class HorseRace
    {
        public Race Race { get; set; }
        public Horse Horse { get; set; }
        public int? PlaceFinished { get; set; } // null if did not finish
        public string JockeyName { get; set; }
        public double HorseWeighIn { get; set; } // weight of horse at time of race
        public double JockeyWeighIn { get; set; } // weight of jockey at time of race
    }
    public enum Gender
    {
        Colt,
        Filly
    }
    public enum Breed
    {
        // fill in breeds here
    }
