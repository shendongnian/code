    public class Group {
      public string Name { get; set; }
      public List<SubGroup> SubGroups { get; set; }
      public Group(string name) { this.Name = name; }
    }
        
    public class SubGroup {
      public string Name { get; set; }
      public SubGroup(string name) { this.Name = name; }
    }
