    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;
    
    namespace WhateverMakesSense
    {
    	public class PathsToXml
    	{
    		private XDocument xDoc;
    		private readonly Dictionary<string, XElement> xElements = new Dictionary<string, XElement>();
    
    		public XDocument GetXDocument(IEnumerable<string> paths)
    		{
    			xDoc = new XDocument();
    
    			foreach (var path in paths)
    			{
    				getElement(path);
    			}
    
    			return xDoc;
    		}
    
    		private XElement getElement(string path)
    		{
    			if (xElements.ContainsKey(path))
    			{
    				return xElements[path];
    			}
    
    			var di = new DirectoryInfo(path);
    			var fullName = di.FullName;
    
    			if (di.Parent == null)
    			{
    				xElements[fullName] = new XElement("node",
    					new XAttribute("label", fullName),
    					new XAttribute("fullpath", fullName));
    				xDoc.Add(xElements[fullName]);
    				return xElements[fullName];
    			}
    
    			var parent = getElement(di.Parent.FullName);
    			var innerMost = Path.GetFileName(fullName) ?? string.Empty;
    
    			xElements[fullName] = new XElement("node",
    				new XAttribute("label", innerMost),
    				new XAttribute("fullpath", fullName));
    			parent.Add(xElements[fullName]);
    			return xElements[fullName];
    		}
    
    		public static IList<string> PathSplit(string path)
    		{
    			var ret = pathSplit(path);
    			ret.Reverse();
    			return ret;
    		}
    		private static List<string> pathSplit(string path)
    		{
    			var ret = new List<string>();
    			var innerMost = Path.GetFileName(path) ?? string.Empty;
    			while (String.IsNullOrWhiteSpace(innerMost) == false)
    			{
    				var di = new DirectoryInfo(path);
    				if (ReferenceEquals(null, di.Parent))
    				{
    					break;
    				}
    				path = di.Parent.FullName;
    				ret.Add(innerMost);
    				innerMost = Path.GetFileName(path) ?? string.Empty;
    			}
    			ret.Add(path);
    			return ret;
    		}
    	}
    }
