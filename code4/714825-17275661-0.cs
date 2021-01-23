    using System.ComponentModel.DataAnnotations.Schema;
    public class Building
    {
        [NotMapped]
        public Location Location { get; private set; }
    }
