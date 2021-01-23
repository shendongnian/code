    public delegate void ActByRef<T1>(ref T1 p1);
    public delegate void ActByRef<T1,T2>(ref T1 p1, ref T2 p2);
    public delegate void ActByRef<T1,T2,T3>(ref T1 p1, ref T2 p2, ref T3 p3);
    public void ActOnSize(ActByRef proc) 
      { proc( ref _someSize); }
    public void ActOnSize<XT1>(ActByRef proc, ref XT1 xp1) 
      { proc( ref _someSize, ref xp1); }
    public void ActOnSize<XT1,XT2>(ActByRef proc, ref XT1 xp1, ref XT2 xp2)
      { proc( ref _someSize, ref xp1, ref xp2); }
