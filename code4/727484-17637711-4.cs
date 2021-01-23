    namespace CustomerDomain.Commands
    {
        public class RegisterNewCustomer : ICommand
        {
            public RegisterNewCustomer(Guid registrationId, string firstName, string lastName, string email, int worksForCompanyId)
            {
                this.RegistrationId = registrationId;
                this.FirstName = firstName;
                // ... more fields
            }
            public readonly Guid RegistrationId;
            public readonly string FirstName;
            // ... more fields
        }
        public class ChangeCustomerEmail : ICommand
        {
            public ChangeCustomerEmail(int customerId, string newEmail)
            // ...
        }
        public class ChangeCustomerCompany : ICommand
        {
            public ChangeCustomerCompany(int customerId, int newCompanyId)
            // ...
        }
        // ... more commands
    }
    namespace CustomerDomain.Events
    {
        public class NewCustomerWasRegistered : IEvent
        {
            public NewCustomerWasRegistered(Guid registrationId, int assignedId, bool isPremiumCustomer, string firstName /* ... other fields */)
            {
                this.RegistrationId = registrationId;
                // ...
            }
            public readonly Guid RegistrationId;
            public readonly int AssignedCustomerId;
            public readonly bool IsPremiumCustomer;
            public readonly string FirstName;
            // ...
        }
        public class CustomerRegistrationWasRefused : IEvent
        {
            public CustomerRegistrationWasRefused(Guid registrationId, string reason)
            // ...
        }
        public class CustomerEmailWasChanged : IEvent
        public class CustomerCompanyWasChanged : IEvent
        public class CustomerWasAwardedPremiumStatus : IEvent
        public class CustomerPremiumStatusWasRevoked : IEvent
    }
