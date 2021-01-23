    [Test]
    public void ReplaceInstance_can_proxy_for_interface_type_when_using_multi_stage_registration()
    {
    	var builder = new ContainerBuilder();
    	builder.RegisterType<Sample>().AsSelf();
    	builder.Register(c => (ISample)c.Resolve<Sample>())
    		   .OnActivating(x => x.ReplaceInstance(new ProxiedSample(x.Instance)))
    		   .SingleInstance();
    	var container = builder.Build();
    
    	var sample = container.Resolve<ISample>();
    	Assert.That(sample, Is.InstanceOf<ProxiedSample>());
    }
