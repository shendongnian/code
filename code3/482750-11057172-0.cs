    public void Execute(IServiceProvider serviceProvider)
    {
        IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
        if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
        {
            var target = ((Entity)context.InputParameters["Target"]);
            if (target.LogicalName == Appointment.EntityLogicalName)
            {
                IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
                var entity = target.ToEntity<Xrm.Appointment>();
                if (entity.Description == null && entity.Attributes.Contains("description"))
                {
                    throw new Microsoft.Xrm.Sdk.SaveChangesException("Fill in the field, buddy.");
                }
            }
        }
    }
