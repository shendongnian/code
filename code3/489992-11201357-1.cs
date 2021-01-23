    using System.Linq;
    using System.Xml.Linq;
    
    string xml = @"<NEWSFEED>
                       <ARTICLE ID='665875' POSTING_DATE='25-Jun-2012'
                                POSTING_TIME='06:00' ARCHIVE_DATE='18-Jun-2013'>
                           <NEWS_TYPE>News</NEWS_TYPE>
                           <HEADLINE>Diabetes Can Make a Comeback After Weight-Loss
                                     Surgery: Study</HEADLINE>
                       </ARTICLE>
                   </NEWSFEED>";
    XElement doc = XElement.Parse(xml);
    var results = doc.Descendants("ARTICLE")
        .Select(d =>
            new 
            {
                ID = d.Attribute("ID").Value ?? "",
                POSTING_DATE = d.Attribute("POSTING_DATE").Value ?? "",
                ARCHIVE_DATE = d.attribute("ARCHIVE_DATE").Value ?? "",
            }).ToList();   
