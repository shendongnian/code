            XDocument xDoc = XDocument.Load(xml.FullName);
            IEnumerable<XElement> monthlyReportElements = from el in xDoc.Descendants("MonthlyReportForm") select el;
            foreach (XElement el in monthlyReportElements)
            {
                teamName = Helper.GetElement("TeamName", el, true);
                reportingDate = string.Format("{0}-{1}", Helper.GetElement("ReportingYear", el, true), Helper.GetElement("ReportingMonth", el, true));
                pdfVersion = Helper.GetElement("FileVersionField", el, true);
                supervisorEmail = Helper.GetElement("SupervisorEmail", el, true);
                return true;
            }
     internal static string GetElement(string elementName, XElement xElement, bool required)
    {
        if (xElement == null
            || string.IsNullOrEmpty(elementName)
            || xElement.Element(elementName) == null
            || xElement.Element(elementName).Value == null)
        {
            if (required)
                throw new Exception(string.Format("Required element '{0}' is missing", elementName));
            else
                return string.Empty;
        }
        return xElement.Element(elementName).Value;
    }
