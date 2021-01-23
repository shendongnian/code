    namespace ConsoleApplication1
    {
        using System;
        using System.Collections.Generic;
        using System.Diagnostics;
        using System.IO;
        using System.Runtime.Serialization.Json;
        using System.Text;
        public class SomeObject
        {
            public string Symbol { get; set; }
        }
        public class MyClass
        {
            public DateTime CacheInsertTime { get; set; }
            public List<object> Data { get; set; }
        }
        public class Program
        {
            private const string JsonString = @"{""CacheInsertDateTime"":""\/Date(1360761324878)\/"",""Data"":[{""__type"":""SomeObject:#ConsoleApplication1"",""Symbol"":""some string""},{""__type"":""SomeObject:#ConsoleApplication1"",""Symbol"":""some other string""}]}";
            private static void Main()
            {
                var ser = new DataContractJsonSerializer(typeof (MyClass), new[] {typeof (SomeObject)});
                var ms = new MemoryStream(Encoding.ASCII.GetBytes(JsonString));
                var obj = (MyClass) ser.ReadObject(ms);
                Trace.Assert(obj.Data.Count == 2);
                Trace.Assert(((SomeObject) obj.Data[1]).Symbol == "some other string");
            }
        }
    }
