    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
    	public class Program
    	{
    		static void Main(string[] args)
    		{
    			SendXML();
    		}
    
    		static void SendXML()
    		{
    			var testObject = new TestModelInput();
    			testObject.Age = 144;
    			testObject.Name = "SomeName";
    			
    			string serializedValue;
    			using (StringWriter writer = new StringWriter())
    			{
    				XmlSerializer serializer = new XmlSerializer(typeof(TestModelInput));
    				serializer.Serialize(writer, testObject);
    
    				serializedValue = writer.ToString();
    			}
    
    			byte[] serializedArray = Encoding.Unicode.GetBytes(serializedValue);
    
    			HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:49231/api/Values");
    			req.Method = "POST";
    			req.ContentLength = serializedArray.Length;
    			req.Accept = "application/xml";
    			req.ContentType = "application/xml; charset=utf-16";
    			
    			using (Stream reqStream = req.GetRequestStream())
    			{
    				reqStream.Write(serializedArray, 0, serializedArray.Length);
    			}
    
    			using (HttpWebResponse resp = (HttpWebResponse) req.GetResponse())
    			{
    				if (resp.StatusCode != HttpStatusCode.OK)
    				{
    					string message = String.Format("POST failed. Received HTTP {0}", resp.StatusCode);
    					throw new ApplicationException(message);
    				}
    
    				StreamReader sr = new StreamReader(resp.GetResponseStream());
    				string response = sr.ReadToEnd();
    
    				Console.WriteLine(response + System.Environment.NewLine);
    			}
    		}
    
    		public class TestModelInput
    		{
    			public string Name { get; set; }
    			public int Age { get; set; }
    		}
    	}
    }
