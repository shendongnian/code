    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CON_SEND
    {
       public fixed byte Command[4];
       public System.UInt16 Lc;
       public fixed byte DataIn[512];
       public System.UInt16 Le;
    }
