    XDocument xdoc = XDocument.Load(s);
    IEnumerable<Student> students =
        from s in xdoc.Descendants("student")
        select new Student()
        {
            Id = (int)s.Element("student_id"), // you can cast to int
            Name = (string)s.Element("student_name"),
            Subjects = s.Element("subjects") // here goes sub query
                        .Elements("subject")
                        .Select(subj => new Subject() { 
                           Name = (string)subj.Element("school_subject") 
                        }).ToList()
        };
