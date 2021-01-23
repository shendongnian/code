        internal Guid CreateEntity(IServiceProvider serviceProvider)
		{
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService organizationService = serviceFactory.CreateOrganizationService(null);
            Entity entityToCreate = new Entity("Some_Entity_LogicalName");
            return organizationService.Create(entityToCreate);
		}
