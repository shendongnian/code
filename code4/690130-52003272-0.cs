    public class PaymentDto
    {
        public int ID { get; set; }
        public DateTime? PaidOn { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
    
        //Navigation Properties
        public virtual PaymentMechanismDto PaymentMechanism { get; set; }
        public virtual ICollection<OrderDto> Orders { get; set; }
    }
    public class PaymentMechanismDto
    {
    //properties
    }
    public class OrderDto
    {
    //properties
    }
    public class MappingProfile : Profile
    {
            public MappingProfile()
            {
                Mapper.CreateMap< Payment, PaymentDto >();
                Mapper.CreateMap< PaymentMechanism, PaymentMechanismDto >();
                Mapper.CreateMap< Order, OrderDto >();
            }
    }
