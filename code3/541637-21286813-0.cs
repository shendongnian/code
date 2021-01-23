        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Runtime.Serialization;
        using System.Xml.Serialization;
        namespace MyFirm.Common.Data
        {
            [DataContract]
            [Serializable]
            public class SerializableClassX
            {
                // since the Dictionary<> class is not serializable,
                // we convert it to the List<KeyValuePair<>>
                [XmlIgnore]
                public Dictionary<string, int> DictionaryX 
                {
                    get
                    {
                        return  SerializableList == null ? 
                                null :
                                SerializableList.ToDictionary(item => item.Key, item => item.Value);
                    }
                    set
                    {
                        SerializableList =  value == null ?
                                            null :
                                            value.ToList();
                    }
                }
                [DataMember]
                [XmlArray("SerializableList")]
                [XmlArrayItem("Pair")]
                public List<KeyValuePair<string, int>> SerializableList { get; set; }
            }
        }
