    public class MyFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost host = base.CreateServiceHost(serviceType, baseAddresses);
            host.Opening += new EventHandler(host_Opening);
            return host;
        }
        void host_Opening(object sender, EventArgs e)
        {
            // do initialization here
        }
    }
}
