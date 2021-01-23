        public XDocument CreateXML(string[][] activities)
        {
            int HomeID = 1;
            XDocument doc = new XDocument();
            doc.Add(new XAttribute("HomeID", ""+HomeID++);
            foreach (string[] dayactivities in activities)
            {
                int ID=1;
                XElement day = new XElement("Day");
                day.Add(new XAttribute("ID", ""+ID++));
                doc.Add(day);
                foreach (string s in dayactivities)
	                day.Add(new XElement("String", s));
            }
            return doc;
        }
