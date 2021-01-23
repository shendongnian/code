    <#@ template language="C#" #>
    <#@ assembly name="System.Core" #>
    <# assembly name="System.Xml" #>
    <#@ import namespace="System.Xml" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="System.IO" #>
    using System;
    using System.Text;
    using System.Xml;
     namespace Test
     {
        public class TestClass
       {
        #region Methods
 
            public static void WriteXml()
            {
		
		using( var writer = XmlWriter.Create("out.xml"))
		{
    <#
      foreach (XmlNode node in this.GetNames())   
    {
	    if(node.NodeType == XmlNodeType.Element) {
    #>
			writer.WriteStartElement(@"<#= node.Name  #>");
    <# }
	 if(node.NodeType == XmlNodeType.Comment) {
    #>
		writer.WriteComment(@"<#= node.Value   #>");
    <# }
	}
    #>
		}
      }
        
        #endregion
     }
    }
    <#+
    
     public IEnumerable<XmlNode> GetNames()
     {
        List<string> result = new List<string>(); 
	    XmlDocument doc = new XmlDocument();		
        string absolutePath = @"c:\data\XMLFile1.xml";                
        doc.Load(absolutePath);
        foreach (XmlNode node in doc.ChildNodes)
        {
            yield return node;
        }
        
    }
    #>
