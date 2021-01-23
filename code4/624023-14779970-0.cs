    private string policyName;
    [XmlAttribute("Type")]
    public string Type
    {
        private get
        {
            return this.policyType;
        }
        set
        {
            this.policyType = value;
            try
            {
                this.PolicyType = (PolicyTypes)Enum.Parse(typeof(PolicyTypes), this.policyType);
            }
            catch(Exception)
            {
                this.PolicyType = PolicyTypes.DefaultPolicy;
            }
        }
    }
    public PolicyTypes PolicyType
    {
        get;
        private set;
    }
