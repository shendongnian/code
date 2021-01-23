    class Program
        {
            private static Stack<Gem> gems = new Stack<Gem>();
            private Stack<Enemy> enemies = new Stack<Enemy>();
            static void Main(string[] args)
            {
                gems.Push(new Gem
                    {
                       BoundingCircle = new BoundingCircle
                           {
                               Name = "abc"
                           }
                    });
    
                gems.Push(new Gem
                {
                    BoundingCircle = new BoundingCircle
                    {
                        Name = "def"
                    }
                });
    
                UpdateGems(new GameTime());
            }
    
            private static void UpdateGems(GameTime gameTime)
            {
                for (int i = 0; i < gems.Count; ++i)
                {
                    Gem gem = gems.Peek();
    
    
                    gem.Update(gameTime);
    
    
                    if (gem.BoundingCircle.Equals(Player.BoundingRectangle))
                    {
                        gems.Pop();
    
                        OnGemCollected(gem, null);
                    }
                }
            }
    
            private static void OnGemCollected(Gem gem, Player player)
            {
                
            }
        }
    
        public class Gem
        {
            public void Update(GameTime gameTime)
            {
                
            }
    
            public BoundingCircle BoundingCircle { get; set; }
        }
    
        public class Enemy
        {
    
        }
    
        public class GameTime
        {
    
        }
    
        public class BoundingCircle : Bounding
        {
            public override bool Equals(object obj)
            {
                var temp = (Bounding) obj;
                return Name.Equals(temp.Name, StringComparison.InvariantCulture);
            }
        }
    
        public class Player
        {
            static Player()
            {
                BoundingRectangle = new BoundingRectangle
                    {
                        Name = "def"
                    };
            }
    
            public static BoundingRectangle BoundingRectangle { get; set; }
        }
    
        public class BoundingRectangle : Bounding
        {
            
        }
    
        public abstract class Bounding
        {
            public string Name { get; set; }
        }
