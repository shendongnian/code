    public class FightCard
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Fight> Fights { get; set; }
    }
    public class Fight
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public FightCard FightCard { get; set; }
        public virtual ICollection<Fighter> Fighters { get; set; }
    }
    public class Fighter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Fight> Fights { get; set; }
    }
