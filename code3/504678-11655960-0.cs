    namespace Smurf
    {
        [Guid("EAA4976A-45C3-4BC5-BC0B-E474F4C3C83F")]
        public interface IPants
        {
            string Explode(bool Loud);
        }
    
        [Guid("7BD20046-DF8C-44A6-8F6B-687FAA26FA71"),
         InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IPantsEvents
        {
            string Explode(bool Loud);
        }
    
        [ComVisible(true)]
        [Guid("0D53A3E8-E51A-49C7-944E-E72A2064F938")]
        [ClassInterface(ClassInterfaceType.None)]
        [ComSourceInterfaces(typeof(IPantsEvents))]
        public class Pants : IPants
        {
    
            [ComVisible(true)]
            public string Explode(bool Loud)
            {
                string result;
                if (Loud)
                    result = "BANG";
                else
                    result = "pop";
                return result;
            }
        }
    }
