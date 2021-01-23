    public class Part
    {
      public virtual string Name { get; set; }
      public virtual double Quantity { get; set; }
      public override string ToString()
      {
        return string.Format("{0}: {1}", this.Name, this.Quantity.ToString());
      }
    }
    public class Order
    {
      public virtual string Name { get; set; }
      public virtual List<Part> Parts { get; set; }
      public override string ToString()
      { 
        return this.Name;
      }
    }
