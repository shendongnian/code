        public enum RegistryLocation
        {
            ClassesRoot,
            CurrentUser,
            LocalMachine,
            Users,
            CurrentConfig
        }
        public RegistryKey GetRegistryLocation(RegistryLocation location)
        {
            switch (location)
            {
                case RegistryLocation.ClassesRoot:
                    return Registry.ClassesRoot;
                case RegistryLocation.CurrentUser:
                    return Registry.CurrentUser;
                case RegistryLocation.LocalMachine:
                    return Registry.LocalMachine;
                
                case RegistryLocation.Users:
                    return Registry.Users;
                case RegistryLocation.CurrentConfig:
                    return Registry.CurrentConfig;
                    
                default:
                    return null;
            }
        }
        public void RegistryWrite(RegistryLocation location, string path, string keyname, string value) {
             RegistryKey key;
             key = GetRegistryLocation(location).CreateSubKey(path);
        }
