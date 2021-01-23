    public abstract class Building 
    {
        // Optional constructor
        protected Building(int id, string name)
        {
             this.ID = id;
             this.Name = name;
        }
        public int ID { get; protected set; }
        public string Name { get; protected set; }
    }
