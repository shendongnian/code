    public class Bootstrapper : UnityBootstrapper
    {
        private IShellViewModel shellViewModel;
        protected override DependencyObject CreateShell()
        {
            // register shell types
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterType<IShellView, ShellWindow>("ShellView");
            container.RegisterType<IShellViewModel, ShellViewModel>("ShellViewModel");
            shellViewModel = container.Resolve<IShellViewModel>("ShellViewModel");
            this.Shell = shellViewModel.View as DependencyObject;
            return this.Shell;
        }
    }
