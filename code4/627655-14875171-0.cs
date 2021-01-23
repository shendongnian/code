    class Program
    {
        static void Main(string[] args)
        {
            HumanDto humanDto = new HumanDto();
            List<Human> humans = new List<Human>();
            humans.Add(new Human(){city = "London", id = 1});
            humans.Add(new Human() { city = "London2", id = 2 });
            humans.Add(new Human() { city = "London3", id = 3 });
            humans.Add(new Human() { city = "London4", id = 4 });
    
            humans.ForEach(e => humanDto.Add(e.city, e.id));
        }
    }
    
    public class Human
    {
        public Int32 id { get; set; }
        public String city { get; set; }
    }
    public class HumanDto
    {
        public List<Int32> Ids { get; set; }
        public List<String> Cities { get; set; }
        public HumanDto()
        {
            Ids = new List<int>();
            Cities = new List<string>();
        }
    
        public void Add(String city, Int32 Id)
        {
            Ids.Add(Id);
            Cities.Add(city);
        }
    }
