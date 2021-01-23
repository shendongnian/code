    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace Test
    {
        public class Program
        {
            public static void Main(string[] args)
            {
    
                Result result1 = new Result
                                     {
                                         arrival_date = new DateTime(2013, 05, 05),
                                         block = new Result.Block { block_id = 80884788 },
                                         id = 230802
                                     };
                Result result2 = new Result
                                     {
                                         arrival_date = new DateTime(2013, 05, 05),
                                         block = new Result.Block { block_id = 419097 },
                                         id = 98121
                                     };
                Results results = new Results { result = new Result[2] };
                results.result[0] = result1;
                results.result[1] = result2;
    
                WriteSettingsAsXml("D:\\test.xml", typeof(Results), results, true);
    
                Results gA = (Results)ReadSettingsFromXml("D:\\test.xml", typeof(Results));
            }
            // This `Result` class below maps to a single result in the XML you provided. This class is used in the `Results` class to obtain the needed XML structure.   
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
    
            /// Library methods that saves/reads any passed/retrieved object into/from a xml file at specified location
            public static void WriteSettingsAsXml(string destinationPath, Type objectType, object objectValue, bool hideNamespaces)
            {
                XmlSerializer serializer = new XmlSerializer(objectType);
                using (TextWriter writer = new StreamWriter(destinationPath))
                {
                    if (hideNamespaces)
                    {
                        XmlSerializerNamespaces hiddenNamespaces = new XmlSerializerNamespaces();
                        hiddenNamespaces.Add("", "");
                        serializer.Serialize(writer, objectValue, hiddenNamespaces);
                    }
                    else
                        serializer.Serialize(writer, objectValue);
                    writer.Close();
                }
            }
            public static object ReadSettingsFromXml(string xmlFilePath, Type objectType)
            {
                XmlSerializer serializer = new XmlSerializer(objectType);
                using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Open))
                {
                    return serializer.Deserialize(fileStream);
                }
            }
        }
    }
