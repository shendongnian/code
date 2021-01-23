    private string agentId;
    public string AgentId
    {
        get
        {
          return agentId ;
        }
        set
        {
          agentId = new string( value.ToCharArray().Where( c => c.IsLetterOrDigit(c) ) ) ;
        }
    }
