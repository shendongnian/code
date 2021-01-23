    public class RegistrationService : IRegistrationService
    {
        [Dependency]
        public IRequiredService RequiredService { get; set; };
    
        public void Register()
        {}
    }
