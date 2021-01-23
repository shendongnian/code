    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace XmlSerializerExample {
	[XmlRoot("gpx")]
	public class Gpx {
            [XmlElement("data")] public int Data;
	}
	[XmlRoot("gpx", Namespace = "http://www.topografix.com/GPX/1/0")]
	public class GpxV1 : Gpx {}
	[XmlRoot("gpx", Namespace = "http://www.topografix.com/GPX/1/1")]
	public class GpxV2 : Gpx {}
	internal class Program {
		private static void Main() {
			var xmlExamples = new[] {
			                  		"<gpx xmlns='http://www.topografix.com/GPX/1/0'><data>1</data></gpx>",
			                  		"<gpx xmlns='http://www.topografix.com/GPX/1/1'><data>2</data></gpx>",
			                  		"<gpx><data>3</data></gpx>",
			                  	};
			var serializers = new[] {
			                  		new XmlSerializer(typeof (Gpx)),
			                  		new XmlSerializer(typeof (GpxV1)),
			                  		new XmlSerializer(typeof (GpxV2)),
			                  	};
			foreach (var xml in xmlExamples) {
				var textReader = new StringReader(xml);
				var xmlReader = XmlReader.Create(textReader);
				foreach (var serializer in serializers) {
					if (serializer.CanDeserialize(xmlReader)) {
						var gpx = (Gpx)serializer.Deserialize(xmlReader);
						Console.WriteLine("Deserialized, type={0}, data={1}", gpx.GetType(), gpx.Data);
					}
				}
			}
		}
	}
}
