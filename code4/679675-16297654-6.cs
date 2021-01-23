    class Student{public int id;public string name,string section}
    List<Student> studentLst=dox.Descendants("Student").Select(d=>
    new Student{
        id=d.Element("Id").Value,
        name=d.Element("Name").Value,
        section=d.Element("Section").Value
       }).ToList();
