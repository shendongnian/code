     [Table('test')]
        public class Test
        {
          [Key]
          public int id {get; set;}
          public decimal price {get; set;}
          public int qty {get; set;}
          [NotMapped]
          public decimal? subTotal {get; set;}
        }
