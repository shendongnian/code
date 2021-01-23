    //convert data.xml to sortedData.xml
    using System;
    using System.Xml.Xsl;
    
    class Sample {
        static public void Main(){
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("dataSort.xslt");
            xslt.Transform("data.xml", "sortedData.xml");
        }
    }
