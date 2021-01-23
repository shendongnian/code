    using System.Xml.Linq;
    using System.Xml.XPath;
    
    namespace TestLinqXpath
    {
        public  static class TestLinqXpath
        {
            public static XElement SelectNearestDescendantEmployee(XElement clicked)
            {
                string Expr =
    @"(self::*[self::Employee]
     | self::node()[not(self::Employee)]
               /descendant-or-self::Manager[Employee][1]/Employee[1]
       )";
                XElement result = clicked.XPathSelectElement(Expr);
    
                return result;
            }
        }
    }
