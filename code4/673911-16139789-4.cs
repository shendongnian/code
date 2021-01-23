    XDocument doc = XDocument.Load(path);
    List<Event> events = (from x in doc.Descendants("Event")
                         select new Event {
                                    Day = Convert.ToInt32(x.Element("Day").Value),
                                    Time = Convert.ToDateTime(x.Element("Time").Value),
                                    Price = Convert.ToDouble(x.Element("Price").Value),
                                    StrEvent = x.Element("Title").Value,
                                    Description = x.Element("Description").Value
                         }).ToList();
