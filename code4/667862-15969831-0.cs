        public static XDocument Serialize(this Calendar obj)
        {
            XDocument doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                writer.WriteStartElement("Calendar");
                foreach (var dayOfWeek in obj.DaysOfWeek)
                {
                    writer.WriteStartElement("DayOfWeek");
                    writer.WriteAttributeString("Id", dayOfWeek.Id.ToString());
                    writer.WriteAttributeString("Code", dayOfWeek.Code);
                    writer.WriteAttributeString("Name", dayOfWeek.Name);
                    writer.WriteEndElement();
                }
                foreach (var monthOfYear in obj.MonthsOfYear)
                {
                    writer.WriteStartElement("MonthOfYear");
                    writer.WriteAttributeString("Id", monthOfYear.Id.ToString());
                    writer.WriteAttributeString("Code", monthOfYear.Code);
                    writer.WriteAttributeString("Name", monthOfYear.Name);
                    writer.WriteEndElement();
                }
            }
            return doc;
        }
