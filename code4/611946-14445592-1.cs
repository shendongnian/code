    private static bool GetChildFromSubject(int styCode, XElement subject)
    {
        if (styCode == 0)
            return subject.Attribute("AllTeachers").Value.Equals("Y");
        else
        {
            return subject.Attribute("SpeciaGuest").Value.Equals("Y") ||
                    subject.Elements("Topic").Attributes("Code")
                    .Any(x => x.Value.Equals("1"));
        }
    }
