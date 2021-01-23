    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    
    namespace OfficeOpenXml
    {
        public class ExcelIgnoredError : XmlHelper
        {
            private ExcelWorksheet _worksheet;
    
            /// <summary>
            /// Constructor
            /// </summary>
            internal ExcelIgnoredError(XmlNamespaceManager ns, XmlNode node, ExcelWorksheet xlWorkSheet) :
                base(ns, node)
            {
                _worksheet = xlWorkSheet;
            }
    
    
            public bool NumberStoredAsText
            {
                get
                {
                    return GetXmlNodeBool("@numberStoredAsText");
                }
                set
                {
                    SetXmlNodeBool("@numberStoredAsText", value);
                }
            }
    
    
            public bool TwoDigitTextYear
            {
                get
                {
                    return GetXmlNodeBool("@twoDigitTextYear");
                }
                set
                {
                    SetXmlNodeBool("@twoDigitTextYear", value);
                }
            }
    
    
            public string Range
            {
                get
                {
                    return GetXmlNodeString("@sqref");
                }
                set
                {
                    SetXmlNodeString("@sqref", value);
                }
            }
        }
    }
