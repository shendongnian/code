    public class Program
	{
		public static void Main(string[] args)
		{
			var settings = new XmlReaderSettings();
			settings.IgnoreWhitespace = true;
			settings.IgnoreComments = true;
			settings.IgnoreProcessingInstructions = true;
			var reader = XmlReader.Create("XMLFile1.xml", settings);
			while (reader.ReadNextElement())
				Console.WriteLine(reader.Name);
		}
	}
