    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.XPath;
    using System.Xml;
    using System.IO;
    using System.Diagnostics;
    
    namespace XmlFileSearchMVP
    {
    
        public class XmlFileSearchModel : IXmlFileSearchModel
        {
            public XmlFileSearchModel()
            {
    
            }
    
            /// <summary>
            /// Search in all files (fitting the wildcard pattern in <paramref name="filter"/>) from the directory
            /// <paramref name="path"/> for the XPath and report each found position in a string in the return value with
            /// the informations:
            /// + absolute file name path
            /// + number of found occurrence
            /// + line number
            /// + column number
            /// </summary>
            /// <param name="path">file system path, containing the XML files, that have to be searched</param>
            /// <param name="filter">file name with wildcards, e. g. "*.xml" or "*.mscx" or "*.gpx"</param>
            /// <param name="xPath">XPath expression (currently only Xml Node resulting XPaths ok)</param>
            /// <returns></returns>
            public IList<string> Search(string path, string filter, string xPath)
            {
    
                string[] files = System.IO.Directory.GetFiles(path, filter);
    
                var result = new List<string>();
    
                for (int i = 0; i < files.Length; i++)
                {
                    XPathDocument xpd = new XPathDocument(files[i]);
                    var xpn = xpd.CreateNavigator();
                    var xpni = xpn.Select(xPath);
    
                    int foundCounter = 0;
                    while (xpni.MoveNext())
                    {
                        foundCounter++;
                        var xn = xpni.Current;
    
                        var xnc = xn.Clone();
    
                        List<int> positions = new List<int>();
                        GetPositions(xn, ref positions);
                        string absXPath = GetAbsoluteXPath(positions);
    
                        // ok if xPath is looking for an element
                        var xpn2 = xpn.SelectSingleNode(absXPath);
                        bool samePosition = xnc.IsSamePosition(xpn2);
    
                        int y = -1;
                        int x = -1;
                        bool gotIt = GotFilePosition(files[i], positions, ref y, ref x);
    
                        result.Add(string.Format("{0} No. {1}: {2} {3} line {4}, col {5}", files[i], foundCounter, absXPath, gotIt, y, x));
    
                    }
                    result.Add(files[i] + " " + foundCounter.ToString());
                }
    
    
    
                return result;
            }
    
            /// <summary>
            /// Evaluates the absolute position of the current node.
            /// </summary>
            /// <param name="node"></param>
            /// <param name="positions">Lists the number of node in the according level, including root, that is first element. Positions start at 1.</param>
            private static void GetPositions(XPathNavigator node, ref List<int> positions)
            {
                int pos = 1;
    
                while (node.MoveToPrevious())
                {
                    pos++;
                }
    
                if (node.MoveToParent())
                {
                    positions.Insert(0, pos);
                    GetPositions(node, ref positions);
                }
            }
    
            private static string GetAbsoluteXPath(List<int> positions)
            {
                StringBuilder sb = new StringBuilder("/", positions.Count * 5 + 1); // at least required...
    
                foreach (var pos in positions)
                {
                    sb.AppendFormat("/*[{0}]", pos);
                }
    
                return sb.ToString();
    
            }
    
    
            /// <summary>
            /// base code from
            /// http://msdn.microsoft.com/en-us/library/system.xml.ixmllineinfo%28v=vs.110%29
            /// </summary>
            /// <param name="xmlFile"></param>
            /// <param name="positions"></param>
            /// <param name="line"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            public static bool GotFilePosition(string xmlFile, List<int> positions, ref int line, ref int column)
            {
    
                // Create the XmlNamespaceManager.
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
    
                // Create the XmlParserContext.
                XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
    
                // Create the reader.
                using (FileStream fs = new FileStream(xmlFile, FileMode.Open, FileAccess.Read))
                {
                    List<int> currPos = new List<int>();
                    XmlValidatingReader reader = new XmlValidatingReader(fs, XmlNodeType.Element, context);
    
                    try
                    {
                        IXmlLineInfo lineInfo = ((IXmlLineInfo)reader);
                        if (lineInfo.HasLineInfo())
                        {
    
                            // Parse the XML and display each node.
                            while (reader.Read())
                            {
    
                                switch (reader.NodeType)
                                {
                                    case XmlNodeType.Document:
                                    case XmlNodeType.Element:
                                        Trace.Write(string.Format("{0} {1},{2}  ", reader.Depth, lineInfo.LineNumber, lineInfo.LinePosition));
    
                                        if (currPos.Count <= reader.Depth)
                                        {
                                            currPos.Add(1);
                                        }
                                        else
                                        {
                                            currPos[reader.Depth]++;
                                        }
                                        Trace.WriteLine(string.Format("<{0}> {1}", reader.Name, GetAbsoluteXPath(currPos)));
    
                                        if (HasFound(currPos, positions))
                                        {
                                            line = lineInfo.LineNumber;
                                            column = lineInfo.LinePosition;
                                            return true;
                                        }
                                        break;
    
                                    case XmlNodeType.Text:
                                        Trace.Write(string.Format("{0} {1},{2}  ", reader.Depth, lineInfo.LineNumber, lineInfo.LinePosition));
                                        Trace.WriteLine(string.Format("{0} {1}", reader.Value, GetAbsoluteXPath(currPos)));
                                        break;
    
                                    case XmlNodeType.EndElement:
                                        Trace.Write(string.Format("{0} {1},{2}  ", reader.Depth, lineInfo.LineNumber, lineInfo.LinePosition));
                                        while (reader.Depth < currPos.Count - 1)
                                        {
                                            currPos.RemoveAt(reader.Depth + 1); // currPos.Count - 1 would work too.
                                        }
                                        Trace.WriteLine(string.Format("</{0}> {1}", reader.Name, GetAbsoluteXPath(currPos)));
                                        break;
    
                                    case XmlNodeType.Whitespace:
                                    case XmlNodeType.XmlDeclaration: // 1st read in XML document - hopefully
                                        break;
                                    case XmlNodeType.Attribute:
    
                                    case XmlNodeType.CDATA:
    
                                    case XmlNodeType.Comment:
    
                                    case XmlNodeType.DocumentFragment:
    
                                    case XmlNodeType.DocumentType:
    
                                    case XmlNodeType.EndEntity:
    
                                    case XmlNodeType.Entity:
    
                                    case XmlNodeType.EntityReference:
    
                                    case XmlNodeType.None:
    
                                    case XmlNodeType.Notation:
    
                                    case XmlNodeType.ProcessingInstruction:
    
                                    case XmlNodeType.SignificantWhitespace:
                                        break;
    
                                }
    
    
                            }
    
                        }
    
                    }
                    finally
                    {
                        reader.Close();
                    }
                    // Close the reader.
    
                }
                return false;
            }
    
            private static bool HasFound(List<int> currPos, List<int> positions)
            {
                if (currPos.Count < positions.Count)
                {
                    return false; // tree is not yet so deep traversed, like the target node
                }
    
                for (int i = 0; i < positions.Count; i++)
                {
                    if (currPos[i] != positions[i])
                    {
                        return false;
                    }
                }
                return true;
            }
    
    
        }
    }
