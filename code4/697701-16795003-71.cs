    public sealed class CreatePurchaseOrderValidator : IValidator<CreatePurchaseOrder>
    {
        private readonly IRepository<Part> partsRepository;
        private readonly IRepository<Supplier> supplierRepository;
        public CreatePurchaseOrderValidator(
            IRepository<Part> partsRepository,
            IRepository<Supplier> supplierRepository)
        {
            this.partsRepository = partsRepository;
            this.supplierRepository = supplierRepository;
        }
        protected override IEnumerable<ValidationResult> Validate(
            CreatePurchaseOrder command)
        {
            var part = this.partsRepository.GetByNumber(command.PartNumber);
            
            if (part == null)
            {
                yield return new ValidationResult("Part Number", 
                    $"Part number {command.PartNumber} does not exist.");
            }
            var supplier = this.supplierRepository.GetByName(command.SupplierName);
            
            if (supplier == null)
            {
                yield return new ValidationResult("Supplier Name", 
                    $"Supplier named {command.SupplierName} does not exist.");
            }
        }
    }
