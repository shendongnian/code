    public class ViewInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // The 'true' here on the InSameNamespaceAs causes windsor to look in all sub namespaces too
            container.Register(Classes.FromThisAssembly().InSameNamespaceAs<ShellViewModel>(true));
        }
    }
