    using System.ComponentModel.DataAnnotations.Schema;
    public class ClassType1
    {
      [Key]
      public int type1_ID { get; set; }
      
      public int type2_ID { get; set; }  // In database, this is a foreign key linked to ClassType2.type2_ID
      
      [ForeignKey("type2_ID")]
      public virtual ClassType2 type2Prop { get; set; }
    }
    public class ClassType2
    {
      [Key]
      public int type2_ID { get;set; }
    }
