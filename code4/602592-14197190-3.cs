    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    
    namespace XDocu
    {
        class Program
        {
            static void Main(string[] args)
            {
            XDocument doc = XDocument.Parse(INPUT_DATA);
            XElement handlers = doc.Element("handlers");
            IEnumerable<XElement> add = null;
            IEnumerable<XElement> pFind = null;
            int oldCount = doc.Element("handlers").Elements().Count();
    
            if (handlers != null)
            {             
                add = handlers.Elements();
                if (add != null)
                {
    
                    pFind = (from itm in add
                                where itm.Attribute("path") != null
                                && itm.Attribute("path").Value != null
                                && itm.Attribute("path").Value == "Reserved.ReportViewerWebControl.axd"
                                select itm);
    
                    if(pFind != null)
                        pFind.LastOrDefault().Remove();
                }
            }
    
                //print it
                if (add != null)
                    Console.WriteLine("Old Count: {0}\nNew Count: {1}", oldCount, add.Count());
            }
    
            const string INPUT_DATA =
            @"<?xml version=""1.0""?>
            <handlers>
            <remove name=""ChartImageHandler"" />            
            <add name=""PageNotFoundhandelarrtf"" path=""*.rtf"" verb=""*"" 
                modules=""IsapiModule""  scriptProcessor=""%windir%\Microsoft.NET\Framework\v2.0.50727\
                aspnet_isapi.dll"" resourceType=""Unspecified""  preCondition=
                ""classicMode,runtimeVersionv2.0,bitness32"" />
            <add name=""ChartImageHandler"" preCondition=""integratedMode"" verb=""GET,HEAD"" path=""ChartImg.axd"" type=""System.Web.UI.DataVisualization.Charting.ChartHttpHandler, System.Web.DataVisualization,  Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"" />
            <add name=""Keyoti_SearchEngine_Web_CallBackHandler_ashx"" verb=""*"" preCondition=""integratedMode"" path=""Keyoti.SearchEngine.Web.CallBackHandler.ashx"" type=""Keyoti.SearchEngine.Web.CallBackHandler, Keyoti2.SearchEngine.Web, Version=2012.5.12.706, Culture=neutral, PublicKeyToken=58d9fd2e9ec4dc0e"" />
            <add path=""Reserved.ReportViewerWebControl.axd"" 
                verb=""*""  type=""Microsoft.Reporting.WebForms.HttpHandler,
                Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral,  PublicKeyToken
                =b03f5f7f11d50a3a"" validate=""false"" />
            </handlers>";
    
        }
    }
