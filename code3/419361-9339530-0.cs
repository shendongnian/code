    public interface IRegionContainer
    {
        IEnumerable<String> RegionNames { get; }
    }
    
        public void RequestClose(string regionName, string viewContract)
        {
            ContainerRegistration registration = _unityContainer.Registrations.SingleOrDefault(t => t.Name == viewContract);
            if (registration == null) throw new Exception("ViewContract is not registered");
            IEnumerable<object> candidateViews = _regionManager.Regions[regionName].Views.Where(t => t.GetType() == registration.MappedToType);
            foreach (object viewInstance in candidateViews)
            {
                var regionContainer = viewInstance as IRegionContainer;
                if (regionContainer != null) //View defines regions?
                {
                    foreach (string rName in regionContainer.RegionNames)
                    {
                        var success = _regionManager.Regions.Remove(rName);
                        if (success == false) throw new Exception("Can't remove region: " + rName);
                    }
                }
                _regionManager.Regions[regionName].Remove(viewInstance);
            }
        }
