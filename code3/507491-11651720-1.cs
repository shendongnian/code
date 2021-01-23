    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    using StackOverflow;
    
    namespace EnumDemo
    {
        [ComVisible(true)]
        [Guid("c30d35fe-2c7f-448b-98be-bd9be567ce70")]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        public interface IEnumDemo
        {
            [DispId(1)]
            EThing Thing
            {
                get;set;
            }
        }
    
        [ComVisible(true)]
        [Guid("af328c82-08e3-403e-a248-8c46e27b48f3")]
        [ClassInterface(ClassInterfaceType.None)]
        [ProgId("StackOverflow.EnumDemo")]
        public class EnumDemo
        {
            private EThing mThing = EThing.eThingOne;
            public EThing Thing { get { return mThing; } set { mThing = value; } }
        }
    }
