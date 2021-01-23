    using System.ComponentModel.DataAnnotations.Schema
    using System.ComponentModel.DataAnnotations
    ...
    
    public class House
    {
            [Column("house_id")]
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
    
            [Column("user_id")]
            public int UserId { get; set; }
    }
