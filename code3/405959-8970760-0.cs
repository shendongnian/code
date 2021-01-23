    private static void CheckForPotentiallyMisconfiguredComponents(IWindsorContainer container)
    {
        var host = (IDiagnosticsHost)container.Kernel.GetSubSystem(SubSystemConstants.DiagnosticsKey);
        var diagnostics = host.GetDiagnostic<IPotentiallyMisconfiguredComponentsDiagnostic>();
        var handlers = diagnostics.Inspect();
        if (handlers.Any())
        {
            var message = new StringBuilder();
            var inspector = new DependencyInspector(message);
            foreach (IExposeDependencyInfo handler in handlers)
            {
                handler.ObtainDependencyDetails(inspector);
            }
            throw new MisconfiguredComponentException(message.ToString());
        }
    }
