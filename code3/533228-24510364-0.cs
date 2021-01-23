    public class InvoiceValidator : AbstractValidator<ContractInvoicingEditModel>
    {
        public InvoiceValidator()
        {
            RuleFor(m => m.EmailAddressTo)
                .Must(CommonValidators.CheckValidEmails).WithMessage("Some of the emails   provided are not valid");
        }
    }
    public static class CommonValidators
    {
        public static bool CheckValidEmails(string arg)
        {
            var list = arg.Split(';');
            var isValid = true;
            var emailValidator = new EmailValidator();
            foreach (var t in list)
            {
                isValid = emailValidator.Validate(new EmailModel { Email = t.Trim() }).IsValid;
                if (!isValid)
                    break;
            }
            return isValid;
        }
    }
    public class EmailValidator : AbstractValidator<EmailModel>
    {
        public EmailValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
        }
    }
    public class EmailModel
    {
        public string Email { get; set; }
    }
