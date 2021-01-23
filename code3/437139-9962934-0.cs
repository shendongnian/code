    [Flags]
    public Enum Permissions
    {
      None =  0;    //0000000
      Read =  1;    //0000001
      Write = 1<<1; //0000010
      Delete= 1<<2; //0000100
      Blah1 = 1<<3; //0001000
      Blah2 = 1<<4; //0010000
    }
