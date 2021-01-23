    public sealed class CreatePurchaseOrderValidator : IValidator<CreatePurchaseOrder>
    {
        private readonly IRepository<Part> partsRepository;
        private readonly IRepository<Supplier> supplierRepository;
        public CreatePurchaseOrderValidator(IRepository<Part> partsRepository,
            IRepository<Supplier> supplierRepository)
        {
            this.partsRepository = partsRepository;
            this.supplierRepository = supplierRepository;
        }
        protected override IEnumerable<ValidationResult> Validate(
            CreatePurchaseOrder command)
        {
            var part = this.partsRepository.Get(p => p.Number == command.PartNumber);
            
            if (part == null)
            {
                yield return new ValidationResult("Part Number", 
                    $"Part number {partNumber} does not exist.");
            }
            var supplier = this.supplierRepository.Get(p => p.Name == command.SupplierName);
            
            if (supplier == null)
            {
                yield return new ValidationResult("Supplier Name", 
                    $"Supplier named {supplierName} does not exist.");
            }
        }
    }
