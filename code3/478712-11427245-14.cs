    protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
            {
                // Call base method
                var mappings = base.ConfigureRegionAdapterMappings();
                if (mappings == null) return null;
    
                // Add custom mappings
                mappings.RegisterMapping(typeof(DockingManager),
                    ServiceLocator.Current.GetInstance<AvalonDockRegionAdapter>());
    
                // Set return value
                return mappings;
            }
