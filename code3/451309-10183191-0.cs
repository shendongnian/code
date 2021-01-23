    public enum States
    {
        None,
        Tenesee,
        Georgia,
        Colorado,
        Florida
    }
    class Item
    {
        public States State { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public bool IsMatch(Item criteria)
        {
            bool match = true;
            if (criteria.State != States.None) match &= criteria.State == State;
            if (!string.IsNullOrEmpty(criteria.Name)) match &= criteria.Name.Equals(Name);
            if (criteria.ID > 0) match &= criteria.ID == ID;
            return match;
        }
        public override string ToString()
        {
            return string.Format("ID={0}, Name={1}, State={2}", ID.ToString(), Name, State.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> list = new List<Item>();
            list.Add(new Item() { ID = 10016, Name = "Julia", State = States.Georgia });
            list.Add(new Item() { ID = 10017, Name = "Scott", State = States.Colorado });
            list.Add(new Item() { ID = 10018, Name = "Samantha", State = States.Tenesee });
            list.Add(new Item() { ID = 10019, Name = "Julia", State = States.Florida });
            Item criteria = new Item()
            {
                State = States.Tenesee,
                ID = 10018
            };
            List<Item> selection = list.FindAll((item) => item.IsMatch(criteria));
            foreach (var item in selection)
            {
                Console.WriteLine("{0}", item);
            }
        }
    }
