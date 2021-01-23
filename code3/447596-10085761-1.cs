    namespace ConsoleApplication1
    {
        interface Info{}
    public class AInfo : Info
    {
        public AInfo(){}
    }
    public class BInfo : Info { }
    class SendInfo {
        public static void f_WriteInfo(params Info[] _info) {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SendInfo.f_WriteInfo( 
                        new Info[] { 
                            new AInfo(),
                            new BInfo()
                       } );
        }
    }
}
