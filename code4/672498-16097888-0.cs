    using System;
    using System.IO;
    using System.Xml;
    
    public class Sample
    {
    
        public static void Main()
        {
    
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<input title='Meluha' Value='1-861001-75-7'>" +
                        "<title>The Imortals of Meluha</title>" +
                        "</input>");
    
            XmlNode root = doc.DocumentElement;
    
            XmlNode value = doc.SelectNodes("//input/@value")[0];
    
            Console.WriteLine("Inner text: " + value.InnerText);
    	
    	XmlNode value = doc.SelectNodes("//title/@value")[0];
            
    	Console.WriteLine("Title text: " + value.InnerText);
         } 
    }
