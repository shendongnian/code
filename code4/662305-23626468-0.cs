    private void GetNetTcpBindingName()
        {
            Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ServiceModelSectionGroup serviceModel = ServiceModelSectionGroup.GetSectionGroup(appConfig);
            BindingsSection oBinding = serviceModel.Bindings;
            List<BindingCollectionElement> bindingCollection = oBinding.BindingCollections;
            NetTcpBindingCollectionElement netTCPBindingCollectionElement = (NetTcpBindingCollectionElement)bindingCollection.Where(obj => obj.BindingName.Equals("netTcpBinding")).SingleOrDefault();
            if (netTCPBindingCollectionElement != null)
            {
                Console.WriteLine(netTCPBindingCollectionElement.ConfiguredBindings.ElementAt(0).Name);
            }
        }
