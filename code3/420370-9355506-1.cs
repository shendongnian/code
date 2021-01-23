    public class Child 
    {
      public int Id ( get; set; }
      public string Name { get; set; }
      public Parent Parent {set;get;}
    }
   
    var x = new MyContext();
    var c1 = new Child { Name = "Alpha-Child" };
    var c2 = new Child { Name = "Beta-Child" };
    var p = new Parent {Name = "Alpha-Parent"};
    c1.Parent = p;
    c2.Parent = p;
    x.Parents.Add(p);
    x.SaveChanges();
