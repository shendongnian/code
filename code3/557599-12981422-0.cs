    Option Explicit
    
    Sub test()
        Dim VBArray(0 To 2) As Double
        VBArray(0) = 1
        VBArray(1) = 2
        VBArray(2) = 3
        
        Dim oComExposedEarlyBinding As New ComExposed
        oComExposedEarlyBinding.SetDoubleArray VBArray
    
    End Sub
----------------------------------------------------------
    using System.Runtime.InteropServices;
    namespace COMVisibleTest
    {
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [Guid("22341123-9264-12AB-C1A4-B4F112014C31")]
        public interface IComExposed
        {
            void SetDoubleArray(ref double[] doubleArray);
        }
        [ClassInterface(ClassInterfaceType.None)]
        [Guid("E4F27EA4-1932-2186-1234-111CF2722C42")]
        [ProgId("ComExposed")]
        public class ComExposed : IComExposed
        {
            private double[] _doubleArray;
            public void SetDoubleArray(ref double[] doubleArray)
            {
                _doubleArray = doubleArray;
            }
        }
    }
