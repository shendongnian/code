    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace Test
    {
    	class MainClass
    	{
    		private static Settings _instance;
    
    		public static void Main (string[] args)
    		{
    			Load ("Settings.xml");
    		}
    
    		public static void Load(string filename)
    		{
    			if (!File.Exists(filename))
    				throw new ArgumentException("File not found.", "filename", new FileNotFoundException());
    
    			//works
    			var doc = new XmlDocument();
    			doc.Load(XmlReader.Create(File.OpenRead(filename)));
    			Console.WriteLine(doc.DocumentElement.FirstChild);
    
    			using (var stream = File.OpenRead(filename))
    			{
    				XmlSerializer serializer = new XmlSerializer(typeof(Settings));
    				_instance = serializer.Deserialize(stream) as Settings;
    			}
    		}
    	}
    
    	public class Settings
    	{
    		public bool EnableHooking {
    			get;
    			set;
    		}
    		public bool IncludePressedKeys {
    			get;
    			set;
    		}
    	}
    }
