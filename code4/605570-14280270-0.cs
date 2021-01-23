        internal Guid CreateEntity(IServiceProvider serviceProvider)
        {
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService organizationService = serviceFactory.CreateOrganizationService(null);
            CreateRequest createRequest = new CreateRequest();
            Entity entityToCreate = new Entity("Some_Entity_LogicalName");
            createRequest.Target = entityToCreate;
            CreateResponse response = (CreateResponse)organizationService.Execute(createRequest);
            return response.id;
        }
