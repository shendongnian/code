    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    
    namespace Serialization_Xml
    {
        class Program
        {
            static void Main(string[] args)
            {
                Data data = new Data();
                List<string> mylist = new List<string>();
                mylist.Add("A");
                mylist.Add("B");
                data.MyProperty = mylist;
                FileStream fs = new FileStream("Data.xml", FileMode.Create);
                XmlSerializer serializer= new XmlSerializer(typeof(Data));
                serializer.Serialize(fs, data);
            }
        }
    
       public class Data
        {
            [XmlIgnore()]
            public List<MyObject> ListMyObjects = new List<MyObject>();
            public List<string> MyProperty
            {
                get
                {
                    List<string> list = new List<string>();
                    foreach (MyObject obj in ListMyObjects)
                        list.Add(obj.Name);
                    return list;
                }
                set
                {
                    foreach (string name in value)
                        ListMyObjects.Add(new MyObject(name));
                }
            }
    
        }
    
        public class MyObject
        {
            public string Name;
            public MyObject(string name)
            {
                Name = name;
            }
        }
    }
