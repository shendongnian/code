    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Xml;
    using System.Configuration;
    namespace Company{
    	public class XXXConfiguration : IConfigurationSectionHandler
    	{
    		/// <summary>
    		/// Initializes a new instance of LoggingConfiguration class.
    		/// </summary>
    		public XXXConfiguration() {}
    
    		private static string _variable;
    
    		public static string Variable
    		{
    			get {return XXXConfiguration._variable; }
    		}
    
    		public object Create(object parent, object configContext, XmlNode section)
    		{
    			// process config section node
    			XXXConfiguration._variable = section.SelectSingleNode("./Variable").InnerText;
    
    			return null;
    		}
    
    	}
    }
