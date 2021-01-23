    public class UserValidator : AbstractValidator<User>
    {
        public enum Mode
        {
            Create,
            Edit
        }
        public UserValidator()
        {
            // Default rules...
        }
        public UserValidator(UserValidator.Mode mode)
            : this()
        {
            if (mode == Mode.Edit)
            {
                // Rules for Edit...
                
                RuleFor(so => so.SomeMember)
                    .SetValidator(
                        new SomeMemberValidator(SomeMemberValidator.Mode.SomeMode))
            }
            if (mode == Mode.Create)
            {
                // Rules for Create...
                
                RuleFor(so => so.SomeMember)
                    .SetValidator(
                        new SomeMemberValidator())
            }
        }
    }
