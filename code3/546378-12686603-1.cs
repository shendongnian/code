#region Usings
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
#endregion Usings
namespace Core.Validation {
    public class OperationValidator : AbstractValidator<Operation> {
        #region .Ctors
        /// <summary>
        /// .Ctor used for operation purpose
        /// </summary>
        public OperationValidator() {
            Validate();
        }
        #endregion .Ctors
        /// <summary>
        /// Validation rules for Operation
        /// </summary>
        private void Validate() {
			//here you may get validations rules from you xml file and structure the following code after your requirements
            //Name
            RuleFor(x => x.Name).Length(2, 20).WithMessage("Operation name should have length between 2 and 20 symbols");
            //ApplicationFormsWrapper
            Custom(entity => {
                foreach (var item in entity.Phases)
                    if (item.PhaseState == null)
                        return new ValidationFailure("Phases", "First Phase is missing");
                return null;
            });
        }
    }
}
