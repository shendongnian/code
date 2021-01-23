    public class Room
    {
        public Room(Suspect suspect, Weapon weapon)
        {
            SuspectInRoom = suspect;
            WeaponInRoom = weapon;
        }
    
        public Suspect SuspectInRoom { get; set; }
        public Weapon WeaponInRoom { get; set; }
    }
    // Example usage:
    
    Suspect coronelCustard = new Suspect("Coronel Custard");
    Weapon musket = new Weapon("Musket");
    
    Room someRoom = new Room(coronelCustard, musket);
    // Then your room can be used to access all sorts of data.
    
    Console.WriteLine(someRoom.SuspectInRoom.Nickname); // "The Big Kahuna"
    Console.WriteLine(someRoom.WeaponInRoom.AttackDamage); // "20"
