       public class Person
       {
          public int ID { get; set; }
          public string Name { get; set; }
          public string Surname { get; set; }
    
          [ForeignKey( "Voucher" )]
          public int? VoucherId { get; set; }
    
          public virtual Voucher Voucher { get; set; }
       }
