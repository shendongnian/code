 public class Throne
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual King King { get; set; }
    }
    public class King
    {
        public int Id { get; set; }
        public virtual Throne Throne { get; set; }
        public string Name { get; set; }
    }
</pre>
