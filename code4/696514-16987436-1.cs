    public class Series
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<State> States { get; set; } 
    }
