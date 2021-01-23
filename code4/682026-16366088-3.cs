            public class Result
            {
                public class Block
                {
                    public Int32 block_id { get; set; }
                }
    
                public DateTime arrival_date { get; set; }
                public Block block { get; set; }
                public Int32 id { get; set; }
            }
    
            [Serializable()]
            [XmlRootAttribute("getAvailability", Namespace = "", DataType = "", IsNullable = false)]
            public class Results
            {
                [XmlElement("result")]
                public Result[] result { get; set; }
            }
    
