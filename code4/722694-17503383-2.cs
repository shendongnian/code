    // in the UI code (this is code for the Autofac IOC container):
    ContainerBuilder cb = ...
    cb.RegisterType<UiCustomer>().As<ICustomerEx>();
    cb.RegisterType<AServiceThatNeedsACustomer>();
    // in the library code
    public class AServiceThatNeedsACustomer {
        private readonly ICustomerEx customer;
        // the customer will get injected by the IOC container
        public AServiceThatNeedsACustomer(ICustomerEx customer) {
            this.customer = customer;
        }
    }
