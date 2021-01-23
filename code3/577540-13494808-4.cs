        private void DeserializeObject(string filename)
        {
            XmlAnyElementAttribute myAnyElement = new XmlAnyElementAttribute();
            XmlAttributeOverrides xOverride = new XmlAttributeOverrides();
            XmlAttributes xAtts = new XmlAttributes();
            xAtts.XmlAnyElements.Add(myAnyElement);
            xOverride.Add(typeof(Employee), "EmployeeDetails", xAtts);
            XmlSerializer ser = new XmlSerializer(typeof(Employee), xOverride);
            FileStream fs = new FileStream(filename, FileMode.Open);
            var g = (Employee)ser.Deserialize(fs);
            fs.Close();
            Console.WriteLine(g.EmployeeDetails.Length);
            foreach (XmlElement xelement in g.EmployeeDetails)
            {
                Console.WriteLine(xelement.Name + ": " + xelement.InnerXml);
            }
        }
