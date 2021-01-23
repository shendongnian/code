     class Program
        {
            static void Main(string[] args)
            {
                var x = new MyContext();
    
                var c1 = new Child { Name = "Alpha-Child" };
                var c2 = new Child { Name = "Beta-Child" };
    
                var p = new Parent { Name = "Alpha-Parent" };
    
                p.Children.Add(c1);
                p.Children.Add(c2);
    
                x.Parents.Add(p);
    
                x.SaveChanges(); 
    
    
                Console.Read();
            }
        }
    
       public class Parent 
       { 
            public Parent() 
            { 
                Children = new List<Child>(); 
            } 
    
           public int Id { get; set; }
            public string Name { get; set; } 
            public List<Child> Children { get; set; } 
        } 
     
        public class Child
        { 
            public int Id { get; set; } 
            public string Name { get; set; } 
        } 
     
        public class MyContext : DbContext 
        { 
            public DbSet<Parent> Parents { get; set; } 
            public DbSet<Child> Children { get; set; } 
        } 
