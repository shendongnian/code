    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    
    namespace ParseXML
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			String xmlString =
    		@"<root type=""service"">
    				<Msg Date=""03/23/2013 12:00:04 AM"">Request'HANDSHAKE'</Msg>
    				<Msg Date=""03/23/2013 12:00:04 AM"">Response'RSHANDSHAKE'</Msg>
    				<Msg Date=""03/23/2013 12:03:04 AM"">Request'HANDSHAKE'</Msg>
    				<Msg Date=""03/23/2013 12:03:04 AM"">Response'RSHANDSHAKE'</Msg>
    				<Msg Date=""03/23/2013 01:34:30 PM"">Request 'IQ~bbabb3ff2-...DLE~VNECTRECVBDHANDLE'</Msg>
    				<Msg Date=""03/23/2013 01:34:30 PM"">Response SIQ~7a23da12...RDHANDLE=O000000000014'</Msg>
    			</root>";
    
    			// Create an XmlReader
    			using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
    			{
    				while (reader.ReadToFollowing("Msg"))
    				{
    					string request = reader.ReadElementContentAsString();
    
    					if(reader.ReadToFollowing("Msg"))
    					{
    						string response = reader.ReadElementContentAsString();
    
    						if (request.Contains("Request") && response.Contains("Response"))
    						{
     							// Request/Response nodes identified...
    						}
    					}
    				}
    			}
    		}
    	}
    }
