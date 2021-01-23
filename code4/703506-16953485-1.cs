    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            static void Main(string[] args)
            {
                // Your member code list
                List<MemberCode> list = new List<MemberCode>();
                
                // Add some members to the list during runtime (replace with your logic)
                list.Add(MemberCode.Field1);
                list.Add(MemberCode.Field2);
                list.Add(MemberCode.Field3);
                list.Add(MemberCode.Field2);
                list.Add(MemberCode.Field1);
                list.Add(MemberCode.field4);
    
                // Create a new serializable member list
                MemberList memberList = new MemberList();
                // Convert your list to a serializable array
                memberList.MemberCode = list.ToArray();
    
                // Write the XML to a file
                XmlSerializer serializer = new XmlSerializer(typeof(MemberList));
                TextWriter writer = new StreamWriter("test.xml");
                serializer.Serialize(writer, memberList);
                
                Console.ReadLine();
            }
        }
    
        [XmlRoot]
        public class MemberList
        {
            [XmlArray("Members")]
            [XmlArrayItem("Member", typeof(MemberCode))]
            public MemberCode[] MemberCode { get; set; }
        }
    
        public enum MemberCode
        {
            Field1 = 1,
            Field2 = 2,
            Field3 = 3,
            field4 = 4
        }
    }
