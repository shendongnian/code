    public class NameObject
    {
         public string Name { get; set; }
         public int Number { get; set; }
    }
    static void Main(string[] args)
    {
         List<NameObject> names = new List<NameObject>();
         names.Add(new NameObject(){ Name="A", Number = 1});
         names.Add(new NameObject(){ Name="B", Number = 1});
         names.Add(new NameObject(){ Name="B", Number = 2});
         names.Add(new NameObject(){ Name="C", Number = 1});
         names.Add(new NameObject(){ Name="C", Number = 2});
         var searchResult = names.Where(x=> x.Name == "C");
    }
