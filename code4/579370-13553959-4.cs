    public class MoveCustomerCommand
    {
        [Range(1, Int32.MaxValue)]
        public int CustomerId { get; set; }
        [Required]
        [ObjectValidator]
        public Address NewAddress { get; set; }
    }
