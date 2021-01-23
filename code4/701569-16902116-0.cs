	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Xml.Serialization;
	namespace Scratch
	{
		[XmlType("ModifiedEnumName")]
		public enum TestEnum
		{
			One,
			Two,
			Three,
		}
		public class TestClass
		{
			public TestClass()
			{
				MyEnums = new List<TestEnum>();
			}
			public List<TestEnum> MyEnums { get; set; }
		}
		static class Program
		{
			static void Main(string[] args)
			{
				using (var sw = new StringWriter())
				{
					new XmlSerializer(typeof(TestClass)).Serialize(sw, new TestClass { MyEnums = { TestEnum.Two } });
					Console.WriteLine(sw.GetStringBuilder());
				}
			}
		}
	}
