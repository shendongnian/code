    public class Mapper
    {
      public List<Objective> Objectives = new List<Objective>();
      public class Objective
      {
        public int ObjectiveId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public ICollection<ObjectiveDetail> ObjectiveDetails { get; set; }
        public Objective()
        {
            ObjectiveDetails = new List<ObjectiveDetail>();
        }
      }
      public class ObjectiveDetail
      {
        public int ObjectiveDetailId { get; set; }
        public int ObjectiveId { get; set; }
        public string Text { get; set; }
        public virtual Objective Objective { get; set; }
      }
      public void Assign()
      {
        var objectiveData = new[] // Hard-coded test data. We don't know what the type of each item in this list is, so I use an anonymous type
        {
          new {Name = "0600", Text = "Header 06"},
          new {Name = "0601", Text = "06 Detail 01"},
          new {Name = "0602", Text = "06 Detail 02"},
          new {Name = "0603", Text = "06 Detail 03"},
          new {Name = "0700", Text = "Header 07"},
          new {Name = "0701", Text = "07 Detail 01"},
          new {Name = "0702", Text = "07 Detail 02"}
        };
        // Create Objectives first
        var id = 1;
        foreach (var item in objectiveData.Where(i => i.Name.EndsWith("00")))
        {
          Objectives.Add(new Objective { ObjectiveId = id, Name = item.Name, Text = item.Text });
          id++;
        }
        // Create ObjectiveDetails
        id = 1;
        foreach (var item in objectiveData.Where(i => !i.Name.EndsWith("00")))
        {
          var itemLocal = item;
          var matchingObjective = Objectives.FirstOrDefault(o => o.Name.StartsWith(itemLocal.Name.Substring(0, 2)));
          var objectiveDetail = new ObjectiveDetail
          {
              ObjectiveDetailId = id,
              Text = item.Text,
              ObjectiveId = matchingObjective != null ? matchingObjective.ObjectiveId : 0,
              Objective = matchingObjective
          };
          if (matchingObjective != null)
          {
              matchingObjective.ObjectiveDetails.Add(objectiveDetail);
          }
          id++;
        }
        // At the end of this method you should have a list of Objectives, each with their ObjectiveDetails children
      }
    }
