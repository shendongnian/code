    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Xml.XPath;
    using HtmlAgilityPack;
    namespace TableRipper
    {
        class Program
        {
            static List<string> SerializeColumnSet(XPathNodeIterator columnSet)
            {
                List<string> serialized = new List<string>();
                while (columnSet.MoveNext())
                {
                    string value = HttpUtility.HtmlDecode(columnSet.Current.Value.ToString().Trim());
                    if (value.Contains(",") || value.Contains("\""))
                    {
                        value = string.Concat('"', value.Replace("\"", "\"\""), '"');
                    }
                    serialized.Add(value);
                }
                return serialized;
            }
            static List<List<string>> RipTable(string url, string xpath, bool includeHeaders = true)
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(url);
                XPathNavigator navigator = document.CreateNavigator();
                XPathNodeIterator tableElementSet = navigator.Select(xpath);
                List<List<string>> table = new List<List<string>>();
                if (tableElementSet.MoveNext())
                {
                    XPathNavigator tableElement = tableElementSet.Current;
                    XPathNavigator tableBodyElement = tableElement.SelectSingleNode("tbody") ?? tableElement;
                    XPathNodeIterator tableRowSet = tableBodyElement.Select("tr");
                    bool hasRows = tableRowSet.MoveNext();
                    if (hasRows)
                    {
                        if (includeHeaders)
                        {
                            XPathNavigator tableHeadElement = tableElement.SelectSingleNode("thead");
                            XPathNodeIterator tableHeadColumnSet = null;
                            if (tableHeadElement != null)
                            {
                                tableHeadColumnSet = tableHeadElement.Select("tr/th");
                            }
                            else if ((tableHeadColumnSet = tableRowSet.Current.Select("th")).Count > 0)
                            {
                                hasRows = tableRowSet.MoveNext();
                            }
                            if (tableHeadColumnSet != null)
                            {
                                table.Add(SerializeColumnSet(tableHeadColumnSet));
                            }
                        }
                        if (hasRows)
                        {
                            do
                            {
                                table.Add(SerializeColumnSet(tableRowSet.Current.Select("td")));
                            }
                            while (tableRowSet.MoveNext());
                        }
                    }
                }
                return table;
            }
            static void Main(string[] args)
            {
                foreach (List<string> row in RipTable(args[0], args[1]))
                {
                    Console.WriteLine(string.Join(",", row));
                }
            }
        }
    }
