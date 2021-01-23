    using System;
    using System.Xml;
    
    class Program
    {
        static void Main()
        {
    	// Create an XML reader for this file.
    	using (XmlReader reader = XmlReader.Create("perls.xml"))
    	{
    	    while (reader.Read())
    	    {
    		// Only detect start elements.
    		if (reader.IsStartElement())
    		{
    		    // Get element name and switch on it.
    		    switch (reader.Name)
    		    {
    			case "perls":
    			    // Detect this element.
    			    Console.WriteLine("Start <perls> element.");
    			    break;
    			case "article":
    			    // Detect this article element.
    			    Console.WriteLine("Start <article> element.");
    			    // Search for the attribute name on this current node.
    			    string attribute = reader["name"];
    			    if (attribute != null)
    			    {
    				Console.WriteLine("  Has attribute name: " + attribute);
    			    }
    			    // Next read will contain text.
    			    if (reader.Read())
    			    {
    				Console.WriteLine("  Text node: " + reader.Value.Trim());
    			    }
    			    break;
    		    }
    		}
    	    }
    	}
        }
    }
