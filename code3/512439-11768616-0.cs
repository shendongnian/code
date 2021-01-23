    using System.Runtime.Serialization;
    using System.IO;
    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                IHelloV1 yoyoData = new YoyoData();
                var serializer = new DataContractSerializer(typeof(YoyoData));
                byte[] bytes;
                using (var stream = new MemoryStream())
                {
                    serializer.WriteObject(stream, yoyoData);
                    stream.Flush();
                    bytes = stream.ToArray();
                }
                IHelloV1 deserialized;
                using (var stream = new MemoryStream(bytes))
                {
                    deserialized = serializer.ReadObject(stream) as IHelloV1;
                }
                if (deserialized != null && deserialized.Yoyo == yoyoData.Yoyo)
                {
                    Console.WriteLine("It works.");
                }
                else
                {
                    Console.WriteLine("It doesn't work.");
                }
                Console.ReadKey();
            }
        }
        public interface IHelloV1
        {
            #region Instance Properties
            [DataMember(Name = "Yoyo")]
            string Yoyo { get; set; }
            #endregion
        }
        [DataContract(Name = "YoyoData", Namespace = "http://hello.com/1/IHelloV1")]
        public class YoyoData : IHelloV1
        {
            public string Yoyo { get; set; }
            public YoyoData()
            {
                Yoyo = "whatever";
            }
        }
    }
