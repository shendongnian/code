       public class ParticipantValidator : AbstractValidator<Participant>
        {
            public ParticipantValidator(DateTime today, int ageLimit, List<string> validCompanyCodes, /*any other stuff you need*/)
            {...}
    
        public void BuildRules()
        {
                 RuleFor(participant => participant.DateOfBirth)
                        .NotNull()
                        .LessThan(m_today.AddYears(m_ageLimit*-1))
                        .WithMessage(string.Format("Participant must be older than {0} years of age.", m_ageLimit));
    
                RuleFor(participant => participant.Address)
                    .NotNull()
                    .SetValidator(new AddressValidator());
    
                RuleFor(participant => participant.Email)
                    .NotEmpty()
                    .EmailAddress();
                ...
    }
    
        }
