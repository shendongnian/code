    public List<string> GetDepartments()
    {
      //query the XML and group by department
       // select only the departments in the group
       var deptQuery =
       from emp in _empXml.Descendants("Employee")
       group emp by emp.Element("Department").Value
       into empGroup
       select empGroup.First().Element("Department").Value;
       return deptQuery.ToList();
    }
