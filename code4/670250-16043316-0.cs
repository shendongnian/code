    var xml = @"<DEMDataSet xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://www.nemsis.org http://nemsis.org/media/XSD_v3/_nemsis_v3.3.1/3.3.1.130201/XSDs/NEMSIS_XSDs_v3.3.1.130201/DEMDataSet_v3.xsd""  xmlns=""http://www.nemsis.org"">
                    <DemographicReport timeStamp=""1969-03-14T07:38:20+07:00"">
                        <dAgency>
                            <dAgency.01>M</dAgency.01>
                        </dAgency>
                    </DemographicReport>
                </DEMDataSet>";
    var xDoc = XDocument.Parse(xml);
    XNamespace ns = "http://www.nemsis.org";
    var result = xDoc.Descendants(ns + "DemographicReport")
                    .Select(d => new DemographicReportGroup
                    {
                        timeStamp = (DateTime)d.Attribute("timeStamp"),
                        Agency = new Agency{EMSAgencyUniqueStateID = d.Descendants(ns + "dAgency.01").First().Value}
                    })
                    .ToList();
---
    public class DemographicReportGroup
    {
        public Agency Agency { set; get; }
        public DateTime timeStamp;
    }
    public class Agency
    {
        public string EMSAgencyUniqueStateID { set; get; }
    }
