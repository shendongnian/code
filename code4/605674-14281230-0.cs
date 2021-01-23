    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml;
    using System.Xml.XPath;
    
    public class Test
    {
    	public static void Main()
    	{
    		var xml = XElement.Parse(@"<variables>
        <variable>
            <name>Name_Value</name>
            <value>Value of Entry</value>
        </variable>
        <variable>
            <name>Name_Value2</name>
            <value>Value of Entry2</value>
        </variable>
    </variables>");
    
    		Console.WriteLine(
                          GetVariableValue(xml, "Name_Value")
                    ); 
    		Console.WriteLine(
                          GetVariableValue(xml, "Name_Value2")
                    ); 
            
    	}
    
            public static string GetVariableValue(XElement xml, string variableName)
            {
                 return xml.XPathSelectElement("variables/variable[name='" + variableName + "']/value").Value;
            }
    }
