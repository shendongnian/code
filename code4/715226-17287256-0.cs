     [ConfigurationProperty("PoolId", IsRequired = true)]
     public string PoolId 
     {
        get { return (string)this["PoolID"]; }
        set { this["PoolID"] = value; }
     }
