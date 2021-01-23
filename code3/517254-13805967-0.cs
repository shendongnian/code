      Bus.Initialize(sbc =>
                {
                    // ... Initialise Settings ...
                    var busConfiguratorr = new PostCreateBusBuilderConfigurator(bus =>
                        {
                            var interceptorConfigurator = new InboundMessageInterceptorConfigurator(bus.InboundPipeline);
                            interceptorConfigurator.Create(new MyIncomingInterceptor(bus));
                        });
                    sbc.AddBusConfigurator(busConfiguratorr);
                });
