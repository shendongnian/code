    public class ServiceHostFactory : 
        System.ServiceModel.Activation.ServiceHostFactory
    {
        protected override System.ServiceModel.ServiceHost CreateServiceHost(Type t, 
            Uri[] baseAddresses)
        {
            return new ServiceHost(t, baseAddresses);
        }
    }
