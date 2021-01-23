    public sealed class PurchaseOrderCommandValidator : Validator<PurchaseOrderCommand>
    {
        private IRepository<Part> partsRepository;
        private IRepository<Supplier> supplierRepository;
        public PurchaseOrderCommandValidator(IRepository<Part> partsRepository,
            IRepository<Supplier> supplierRepository)
        {
            this.partsRepository = partsRepository;
            this.supplierRepository = supplierRepository;
        }
        protected override IEnumerable<ValidationResult> Validate(
            PurchaseOrderCommand command)
        {
            var part = this.partsRepository.Get(p => p.Number == command.PartNumber);
            
            if (part == null)
            {
                yield return new ValidationResult("Part Number", 
                    string.Format("Part number {0} does not exist.", 
                        partNumber));
            }
            var supplier = this.supplierRepository.Get(p => p.Name == command.SupplierName);
            
            if (supplier == null)
            {
                yield return new ValidationResult("Supplier Name", 
                    string.Format("Supplier named {0} does not exist.", 
                        supplierName));
            }
        }
    }
