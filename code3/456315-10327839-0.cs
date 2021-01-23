    ObjectFactory.Configure(
                x =>
                {
                    x.For<GetFilesService.Service1Client>().HybridHttpOrThreadLocalScoped().Use(ctx =>
                        {
                            // Setup logic goes here
                            return new GetFilesService.Service1Client("NetTcpBinding_IService1", "net.tcp://localhost:8089/test");
                        });
                }
            );
