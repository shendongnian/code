    public abstract class Item
    {
        public string Name { get; set; }
    }
    public class Music : Item
    {
        public double Price { get; set; }
    }
    public class Game : Item
    {
        public string Image { get; set; }
    }
    public class Inventory<E> where E : Item
    {
        private IList<E> _games;
        private IList<E> _musics;
        public Inventory()
        {
            _games = new List<E>();
            _musics = new List<E>();
        }
        public void Add(E item)
        {
            if (typeof(E) == typeof(Game))
            {
                _games.Add(item);
            }
            if (typeof(E) == typeof(Music))
            {
                _musics.Add(item);
            }
        }
        public List<E> GetCollection()
        {
            return _musics;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Inventory<Item> inventory = new Inventory<Item>();
            var music1 = new Music() { Name = "aa", Price = 10 };
            var music2 = new Music() { Name = "bb", Price = 20 };
            inventory.Add(music1);
            inventory.Add(music2);
            List<Item> myMusics = inventory.GetCollection();
        }
    }
