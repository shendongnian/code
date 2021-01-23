    public class ControllerFactory : IControllerFactory
    {
        public ControllerFactory() { }
        // Property dependency (part of IControllerFactory interface)
        public IUserInformationProvider UserInformation { get; set; }
    }
