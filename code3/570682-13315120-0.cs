    class Program
    {
        public static int health = 100;
        public static int damage = 0;
        public static int hit = 0;
        static void Main(string[] args)
        {
            if (hit == 1)
            {
                health = health - damage; // health -= damage;
            }
        }
    }
