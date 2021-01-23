    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    using System.Reflection;
    using System.ComponentModel;
    
    
    public class MyClass
    {
    	public static void RunSnippet()
    	{
    		XmlNode node = default(XmlNode);
    		if(node == null)
    			Console.WriteLine(bool.TrueString);
    		if(node != null)
    			Console.WriteLine(bool.FalseString);
    		
    		XmlDocument doc = new  XmlDocument();
    		
    		node = doc.CreateNode (XmlNodeType.Element,"Query", string.Empty);
    		
    		node.InnerXml=@"<Where><Eq><FieldRef Name=""{0}"" /><Value Type=""{1}"">{2}</Value></Eq></Where>";
    		
    		string xmlData = ToXml<XmlNode>(node);
    		
    		Console.WriteLine(xmlData);
    		
    		XmlNode node1 = ConvertFromString(typeof(XmlNode), @"<Query><Where><Eq><FieldRef Name=""{0}"" /><Value Type=""{1}"">{2}</Value></Eq></Where></Query>") as XmlNode;
    		if(node1 == null)
    			Console.WriteLine(bool.FalseString);
    		if(node1 != null)
    			Console.WriteLine(bool.TrueString);
    
    		string xmlData1 = ToXml<XmlNode>(node1);
    		Console.WriteLine(xmlData1);
    	}
        public static string ToXml<T>(T t)
    	{
    		string Ret = string.Empty;
    		XmlSerializer s = new XmlSerializer(typeof(T));
    		using (StringWriter Output = new StringWriter(new System.Text.StringBuilder()))
    		{
    			s.Serialize(Output, t);
    			Ret = Output.ToString();
    		}
    		return Ret;
    	}
            public static object ConvertFromString(Type t, string sourceValue)
            {
                object convertedVal = null;
    
                Type parameterType = t;
                if (parameterType == null) parameterType = typeof(string);
                try
                {
    
                    // Type t = Type.GetType(sourceType, true);
                    TypeConverter converter = TypeDescriptor.GetConverter(parameterType);
                    if (converter != null && converter.CanConvertFrom(typeof(string)))
                    {
                        convertedVal = converter.ConvertFromString(sourceValue);
                    }
                    else
                    {
                        convertedVal = FromXml(sourceValue, parameterType);
                    }
                }
                catch { }
                return convertedVal;
            }
    		      public static object FromXml(string Xml, Type t)
            {
                object obj;
                XmlSerializer ser = new XmlSerializer(t);
                using (StringReader stringReader = new StringReader(Xml))
                {
                    using (System.Xml.XmlTextReader xmlReader = new System.Xml.XmlTextReader(stringReader))
                    {
                        obj = ser.Deserialize(xmlReader);
                    }
                }
                return obj;
            }
    	
    	#region Helper methods
    	
    	public static void Main()
    	{
    		try
    		{
    			RunSnippet();
    		}
    		catch (Exception e)
    		{
    			string error = string.Format("---\nThe following error occurred while executing the snippet:\n{0}\n---", e.ToString());
    			Console.WriteLine(error);
    		}
    		finally
    		{
    			Console.Write("Press any key to continue...");
    			Console.ReadKey();
    		}
    	}
    
    	private static void WL(object text, params object[] args)
    	{
    		Console.WriteLine(text.ToString(), args);	
    	}
    	
    	private static void RL()
    	{
    		Console.ReadLine();	
    	}
    	
    	private static void Break() 
    	{
    		System.Diagnostics.Debugger.Break();
    	}
    
    	#endregion
    }
