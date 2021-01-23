     public class Location
            {
                public int Id { get; set; }
                [Required]
                [StringLength(20)]
                public string LocationName { get; set; }
                public virtual ICollection<Software> Softwares { get; set; }
            }
