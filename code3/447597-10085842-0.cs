    interface Info { }
    
    class AInfo : Info { }
    class BInfo : Info { }
    
    class SendInfo
    {
        public static void f_WriteInfo(params Info[] _info)
        {
        }
    }
    
    class Test
    {
        static void Main()
        {
            SendInfo.f_WriteInfo(new AInfo(), new BInfo());
        }
    }
