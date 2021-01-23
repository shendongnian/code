    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace TestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                var xml = @"   <home>
          <prop1>aaaaa</prop1>
          <prop2>bbbbb</prop2>
          <prop3>cccccc</prop3>
        </home>";
    
                var reader = new StringReader(xml);
                var serializer = new XmlSerializer(typeof(BaseModel), "");
                var instance = (BaseModel)serializer.Deserialize(reader);
    
                Assert.AreEqual("aaaaa", instance.prop1);
                Assert.AreEqual("bbbbb", instance.prop2);
                Assert.AreEqual("cccccc", instance.prop3);
            }
        }
    
        [Serializable]
        [DataContract(Namespace = "www.doesnotmatter.com")]
        [XmlRoot("home")]
        public partial class BaseModel
        {
            [DataMember(IsRequired = false)]
            public string prop1
            { get; set; }
    
            [DataMember(IsRequired = false)]
            public string prop2
            { get; set; }
    
            [DataMember(IsRequired = false)]
            public string prop3
            { get; set; }
        }
    }
