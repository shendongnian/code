    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.Serialization;
    
    namespace ConsoleApplication30
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test a = new Test(1, 2);
                Test b;
                using (var ms = new MemoryStream())
                {
                    DataContractSerializer ser = new DataContractSerializer(typeof(Test));
                    ser.WriteObject(ms, a);
                    ms.Position = 0;
                    b = (Test) ser.ReadObject(ms);
                }
                Trace.Assert(a.Data1 == b.Data1);
                Trace.Assert(a.Data2 == b.Data2);
            }
        }
    
        [DataContract]
        public class Test
        {
            [DataMember]
            public readonly int Data1;
    
            [DataMember]
            private readonly int _data2;
            public int Data2
            {
                get { return _data2; }   
            }
    
            public Test(int data1, int data2)
            {
                Data1 = data1;
                _data2 = data2;
            }
        }
    }
