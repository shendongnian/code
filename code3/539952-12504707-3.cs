    using System.Xml;
    public static void Main(String args[])
    {
        XmlDocument foo = new XmlDocument();
        //Let's assume that the IP of the target player is in args[1]
        //This allows us to parameterize the Load method to reflect the IP address
        //of the user per the OP's request
        foo.Load( String.Format("http://freegeoip.net/xml/{0}",args[1])); 
        XmlNode root = foo.DocumentElement;
        // you might need to tweak the XPath query below
        XmlNode countryNameNode = root.SelectSingleNode("/Response/CountryName");
        
        Console.WriteLine(countryNameNode.InnerText);
    }
