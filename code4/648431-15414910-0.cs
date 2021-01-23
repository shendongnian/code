    namespace BirdsAndEggs
    {
        public class Bird
        {
            public string Name { get; set; }
            public List<Egg> Eggs { get; set; }
        }
        public class Egg
        {
            public string Size { get; set; }
        }
    
        public class Main
        {
            List<Bird> TheBirds = new List<Bird>();
    
            void main()
            {
                TheBirds.Add(new Bird()
                {
                    Name = "Bird 1"
                });
                TheBirds.Add(new Bird()
                {
                    Name = "Bird 2"
                });
                TheBirds.Add(new Bird()
                {
                    Name = "Bird 3"
                });
    
                layEgg(0, "Large");
                layEgg(1, "Medium");
                layEgg(2, "Small");
            }
    
            void layEgg(int i, string size)
            {
                TheBirds[i].Eggs.Add(new Egg() { Size = size });
            }
        }
    }
