    using System.Xml;
    using System.IO;
    using System.Text;
    using System;
    
     public class Example
    {
       public static void Main()
       {
            XmlDocument xmlDoc= new XmlDocument(); 
            
            try {
                xmlDoc.Load("files.xml"); 
            }catch(System.Xml.XmlException e){
                Console.WriteLine(e);   
            }
    
            XmlNodeList defs = xmlDoc.GetElementsByTagName("File");
    
            for (int i = 0; i < defs.Count; i++)
            {
                string fn = defs[i].Attributes["FileName"].Value;
                string fh = defs[i].Attributes["FileHash"].Value;
                Console.WriteLine("File:  " + fn + "\tHash:  " + fh);
            }  
        }
    }
