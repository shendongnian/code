    using System.ComponentModel.DataAnnotations;
    public class Semaphore : MyEntityBase //contains audit properties
    {
        [Required]
        [ConcurrencyCheck]
        public bool InUse { get; set; }
        public string Description { get; set; }
    }
