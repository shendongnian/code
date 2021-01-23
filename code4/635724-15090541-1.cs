    struct ConfigKey
    {
         public readonly int Style;
         public readonly string Slope;
         public ConfigKey(int style, string slope) 
         {
            this.Style = style;
            this.Slope= slope;
         }
         public override bool Equals(object obj)
         {
             if (!(obj is ConfigKey))
             {
                 return false;
             }
             ConfigKey other = (ConfigKey)obj;
             return this.Style == other.Style && this.Slope == other.Slope;
         }
         public override int GetHashCode()
         {
             return Style.GetHashCode() ^ Slope.GetHashCode();
         }
    }
    struct Config
    {
        String  Range {get; set;}
        Double Step { get; set; }
    }
    Dictionary<ConfigKey, Config> conf = new Dictionary<ConfigKey, Config>();
    public Config GetConfig(int style, string slope)
    {
        return conf[new ConfigKey(style, slope)];
    }
