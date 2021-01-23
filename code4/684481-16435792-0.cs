    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    static class Program {
        static void Main() {
            var order = new Order {
                ClientId = 1001,
                Id = 58239346,
                Config = new OrderConfig {
                    Id = 19,
                    Properties = {
                        new OrderProperty { Key = "RecordTotal", Value = "10"},
                        new OrderProperty { Key = "InputFileName", Value = "name"},
                        new OrderProperty { Key = "ConfigName", Value = "COMMON_"},
                        new OrderProperty { Key = "DeliveryDate", Value = "15-FEBRUARY-2013"},
                        new OrderProperty { Key = "Qualifier", Value = "name"}
                    }
                }
            };
            var ser = new XmlSerializer(typeof(Order));
            ser.Serialize(Console.Out, order);
        }
    }
    [XmlRoot("order")]
    public class Order {
        [XmlElement("clientID", Order = 0)]
        public int ClientId { get; set; }    
        [XmlElement("config", Order = 1)]
        public OrderConfig Config { get; set; }    
        [XmlElement("orderID", Order = 2)]
        public int Id { get; set; }
    }
    
    public class OrderConfig {
        [XmlElement("id", Order = 2)]
        public int Id { get; set; }    
        private readonly List<OrderProperty> properties = new List<OrderProperty>();
        [XmlArray("properties", Order = 1), XmlArrayItem("entry")]
        public List<OrderProperty> Properties { get { return properties; } }
    }
    
    public class OrderProperty {
        [XmlAttribute("key")]
        public string Key {get;set;}
        [XmlText]
        public string Value {get;set;}
    }
