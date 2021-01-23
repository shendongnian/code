    public class BaseModel
    {
        public virtual string RequiredProperty { get; set; }
    }
    
    public class DerivativeModel : BaseModel
    {
        [Required]
        public override string RequiredProperty { get; set; }
    }
    public class DerivativeModel2 : BaseModel
    {
        [Range(1, 10)]
        public override string RequiredProperty { get; set; }
    }
