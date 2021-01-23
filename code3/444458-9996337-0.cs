    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    class Program {
        static void Main(string[] args) {
            System.Collections.IList list = new List<int> { 1, 2, 3 };
            var ser = new XmlSerializer(list.GetType());
            ser.Serialize(Console.Out, list);
            Console.ReadLine();
        }
    }
