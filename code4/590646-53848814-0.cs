    class Program
    {
        static void Main(string[] args)
        {
            Bed bed = RoomObject.RoomName("Bed");
            Console.WriteLine(bed.name);
           //outline:Bed
            Console.Read();
        }
    }
    public class RoomObject
    {
        public static Bed RoomName(string BedName)
        {
            Bed newBed = new Bed();
            newBed.name = BedName;
            return newBed;
        }
    }
    public class Bed
    {
        public string name { get; set; }
    }
