    using System.Xml.Linq;
    
         XNamespace ns1 = "Feedbacks";
         XNamespace ns2 = "Feedback";
    
         var doc = new XElement("Feedbacks", 
                new XAttribute(XNamespace.Xmlns+"Feedbacks", ns1));
         doc.Add(new XElement(ns1 + "Elements", 
                new XElement(ns2 + "Feedback", 
                   new XAttribute(XNamespace.Xmlns+"Feedback", ns2),
                   new XElement(ns2 + "Unit"))));
