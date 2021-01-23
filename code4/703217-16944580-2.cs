   	using System;
	using DAL.XML.PDD.PDDORDM001;
	using System.Xml.Serialization;
	using System.IO;
	namespace Tests
	{
		class Serialize
		{
			public static void Main()
			{
				Console.WriteLine("Serialisation...");
				XmlSerializer serializer = new XmlSerializer(typeof(DAL.XML.PDD.PDDORDM001.Body));
				TextWriter writer = new StreamWriter(@"c:\file.xml");
				DAL.XML.PDD.PDDORDM001.Bodytest = new DAL.XML.PDD.PDDORDM001.Body();
				test.header= new BodyHeader();
				test.header.action = "LEC";
				test.header.user = "BOBBY";
				test.in= new BodyIn();
				test.in.customer= "07251005502";
				serializer.Serialize(writer, test);
				writer.Close();
			}
		}
	}
