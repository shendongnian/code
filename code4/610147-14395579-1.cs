    // The message
    public class LoginModelChanged
    {
        public LoginModelChanged(LoginModel model)
        {
            Model = model;
        }
        public LoginModel Model { get; private set; }
    }
    // Service that publishes messages
    public class ModelProviderService
    {
        private IMessageBus _messageBus;
        private LoginModel _loginModel;
        public ModelProviderService(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }
        public LoginModel LoginModel
        {
            get { return _loginModel; }
            set
            {
                _loginModel = value;
                _messageBus.Publish(new LoginModelChanged(value));
            }
        }
    }
    // Subscribing ViewModel
    public class SomeViewModel : IHandle<LoginModelChanged>
    {
        public SomeViewModel(IMessageBus messageBus)
        {
            messageBus.Subscribe(this);
        }
        public void Handle(LoginModelChanged message)
        {
            // Do something with message.Model
        }
    }
        
