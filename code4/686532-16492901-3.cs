    using System.ComponentModel.DataAnnotations.Schema;
    
    public abstract class OilFilterBase
    {
      public Guid Id { get; set; }
      public string Title { get; set; }
      public int Price { get; set; }
      public int Amount { get; set; }
      public Guid WarehouseId { get; set; }
    }
    public class Oil : OilFilterBase
    {
    }
    public class Filter : OilFilterBase
    {
    }
    public class Warehouse
    {
      public Guid Id { get; set; }
      [ForeignKey("WarehouseId")]
      public virtual ICollection<Filter> Filters { get; set; }
      [ForeignKey("WarehouseId")]
      public virtual ICollection<Oil> Oils { get; set; }
    }
