            container.Register(
                Component.For<IRedisClientsManager>()
                         .Instance(redisClients)
                         .LifestyleSingleton(),
                Component.For<IRedisClient>()
                         .UsingFactoryMethod(c => c.Resolve<IRedisClientsManager>().GetClient(),
                                            managedExternally: true));
        }
