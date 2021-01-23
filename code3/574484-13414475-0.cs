    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    public class Bowl {
        [XmlArray("Fruits")]
        [XmlArrayItem("Apple", typeof(Apple))]
        [XmlArrayItem("Banana", typeof(Banana))]
        public List<Fruit> Fruits { get; set; }
    }
    public abstract class Fruit { }
    public class Apple : Fruit { }
    public class Banana : Fruit { }
    static class Program {
        static void Main() {
            var ser = new XmlSerializer(typeof(Bowl));
            var obj = new Bowl {
                Fruits = new List<Fruit> {
                    new Apple(), new Banana()
                }
            };
            ser.Serialize(Console.Out, obj);
        }
    }
