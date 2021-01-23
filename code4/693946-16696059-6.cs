    public class Farm
    {
      ....
      public virtual ICollection<Fruit> Fruits { get; set; }
      [NotMapped]
      public IList<Fruit> FilteredFruits { get; set; }
    }
