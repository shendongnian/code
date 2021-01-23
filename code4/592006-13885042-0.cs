        [ResourceExposure(ResourceScope.Machine)]
        [ResourceConsumption(ResourceScope.Machine)]
        public static void Delete(String path, bool recursive)
        { 
            String fullPath = Path.GetFullPathInternal(path);
            Delete(fullPath, path, recursive, true); 
        } 
