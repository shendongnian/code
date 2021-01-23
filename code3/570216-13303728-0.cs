    class ConfigEqualityComparer : IEqualityComparer<ConfigurationItem>
    {
        public bool Equals(ConfigurationItem a, ConfigurationItem b)
        {
            if (a.ConfigKey == b.ConfigKey)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetHashCode(ConfigurationItem a)
        {
                //do some hashing here
                //int hCode = IntegerField1 ^ IntegerField2;
                return hCode.GetHashCode();
        }
    }
