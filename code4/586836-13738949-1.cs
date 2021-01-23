     using (ChannelFactory<ISomeService> channel = new ChannelFactory<ISomeService>("SomeService"))
                {
                    ISomeService svc = channel.CreateChannel();
                    svc.Execute("my expression to evaluate by the service");
                 }
