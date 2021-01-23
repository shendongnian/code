    public class SingleType
    {
        public string Name;
        public int Value;
    }
    List<SingleType> typeList = new List<SingleType>();
    typeList.Add (new SingleType { Name = "TypeA", Value = 1 });
    typeList.Add (new SingleType { Name = "TypeA", Value = 3 });
    typeList.Remove (typeList.Where (t => t.Name == "TypeA" && t.Value == 1).Single());
