        GlobalHost.HubPipeline.EnableAutoRejoiningGroups();
        GlobalHost.DependencyResolver.UseServiceBus(
            serviceBusConnectionString,
            2,
            3,
            GetRoleInstanceNumber(),
              topicPathPrefix /* the prefix applied to the name of each topic used */
            );
