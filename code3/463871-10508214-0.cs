    public FeedbkPrincipal FeedbkPrincipal
    {
        get
        {
            return User as FeedbkPrincipal;
        }
    }
    public FeedbkIdentity FeedbkIdentity
    {
         get
         {
             return FeedbkPrincipal.Identity as FeedbkIdentity;
         }
    }
