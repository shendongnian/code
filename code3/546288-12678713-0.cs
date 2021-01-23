                private ServiceHost serviceHost;
                if (serviceHost != null)
                    serviceHost.Close();
                if (log.IsInfoEnabled)
                    log.Info("Starting WCF service host for endpoint: " + ConfiguredWCFEndpoint);
                // Create our service instance, and add create a new service host from it
                ServiceLayer.TagWCFService service = new ServiceLayer.TagWCFService(ApplicationName,
                    ApplicationDescription,
                    SiteId,
                    ConfiguredUpdateRateMilliseconds);
                serviceHost = new ServiceHost(service, new Uri(ConfiguredWCFEndpoint));
                // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();
