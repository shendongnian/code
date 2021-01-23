namespace Core.Domain {
    public class Operation : ValidatableDomainObject {
		#region Properties
        public virtual String Name { get; set; }
		public virtual ISet<Phase> Phases { get; set; }		
		#endregion Properties
		
        #region Validation
        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<OperationValidator, Operation>(this);
        }
        #endregion Validation		
    }
}
