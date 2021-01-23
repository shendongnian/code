    class MyModel 
    {
        ...
        [Required, StringLength(42)]
        [ValidatorService(typeof(MyDiDependentValidator), ErrorMessage = "It's simply unacceptable")]
        public string MyProperty { get; set; }
        ....
    }
    
    public class MyDiDependentValidator : Validator<MyModel>
    {
        readonly IUnitOfWork _iLoveWrappingStuff;
    
        public MyDiDependentValidator(IUnitOfWork iLoveWrappingStuff)
        {
            _iLoveWrappingStuff = iLoveWrappingStuff;
        }
    
        protected override bool IsValid(MyModel instance, object value)
        {
            var attempted = (string)value;
            return _iLoveWrappingStuff.SaysCanHazCheez(instance, attempted);
        }
    }
