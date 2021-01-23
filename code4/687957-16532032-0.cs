    public class Character
    {
        public string Name;
        public int Level;
        static Random random = new Random();
    
        public static Character CreateNew()
        {
            Character newOne = new Character();
            newOne.Level = random.Next(1, 5);
            newOne.Name = (random.Next(1, 2) == 1) ? "Me" : "You";
            return newOne;
        }
    }
