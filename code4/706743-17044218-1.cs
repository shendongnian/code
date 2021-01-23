    [XmlElement(Name = "branch")]
    public class Branch
    {
        [XmlAttribute(Name = "id")]
        public int Id { get; set; }
    }
    var branches = new List<Branch>();
    branches.Add(new Branch { Id = 1 });
    branches.Add(new Branch { Id = 2 });
    branches.Add(new Branch { Id = 3 });
    
    // Define the root element to avoid ArrayOfBranch
    var serializer = new XmlSerializer(typeof(List<Branch>),
                                       new XmlRootAttribute("Branches"));
    using(var stream = new StringWriter())
    {
        serializer.Serialize(stream, branches);
        stream.ToString().Dump();
    }
