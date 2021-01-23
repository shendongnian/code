    static void Main(string[] args)
		{
			string doc = @"
                        <application name=""Test Tables"">
                        <test>
                          <xs:schema id=""test"" xmlns="""" xmlns:xs=""http://www.w3.org/2001/XMLSchema""                         xmlns:msdata=""urn:schemas-microsoft-com:xml-msdata"">   
                          </xs:schema> 
                        </test>
                        </application>
                        ";
			XDocument xDoc = XDocument.Parse(doc);
			Console.Write(xDoc.ToString());
			Console.ReadLine();
			
			string descendants = xDoc.Descendants("application").DescendantNodes().First().ToString();
			xDoc = XDocument.Parse(descendants);
			Console.Write(xDoc.ToString());
			Console.ReadLine();
		}
