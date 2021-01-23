    var xml = XElement.Parse("");
    var students = xml.Descendants("student");
    students.ToDictionary(x => x.Element("name").Value,
        x => x.Descendants("course")
            .ToDictionary(y => y.Element("name").Value,
                y => int.Parse(y.Element("mark").Value)));
