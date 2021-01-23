    List<string> lines = new List<string>();
    foreach(var phoneBookCore in elements)
    {
        lines.Add(phoneBookCore.GroupName);  // Adds the Group Name
        foreach(var person in phoneBookCore.Persons)
        {
            // Adds the information on the person
            lines.Add(String.Format("FirstName-{0}", person.FirstName));
            lines.Add(String.Format("LastName-{0}", person.LastName));
            lines.Add(String.Format("Address-{0}", person.Address));
            lines.Add(String.Format("PhoneNumber-{0}", person.PhoneNumber));
        }
    }
    System.IO.File.WriteAllLines(path,lines);
