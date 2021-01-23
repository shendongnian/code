    namespace ExampleCF
    {
        public class Foo
        {
            public int FooId { get; set; }
            public virtual List<Bar> Bars { get; set; }
        }
    
        public class Bar
        {
            public int BarId { get; set; }
            public virtual Foo Foo { get; set; }
            public int FooId { get; set; }
            public virtual List<Employee> Employees { get; set; }
        }
    
        public class Employee
        {
            public int EmployeeId { get; set; }
            public int BarId { get; set; }
            public virtual Bar Bar { get; set; }
            public int BankId { get; set; }
            public virtual Bank Bank { get; set; }
            public int PositionId { get; set; }
            public virtual Position Position { get; set; }
            public string Name { get; set; }
        }
    
        public class Bank
        {
            public int BankId { get; set; }
            public string Name { get; set; }
        }
    
        public class Position
        {
            public int PositionId { get; set; }
            public string Name { get; set; }
        }
    
        public class Model : DbContext
        {
            public DbSet<Foo> Foos { get; set; }
            public DbSet<Bar> Bars { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Bank> Banks { get; set; }
            public DbSet<Position> Positions { get; set; }
    
            public Model()
            {
                Configuration.LazyLoadingEnabled = false;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Model context = new Model();
                var exp = new Collection<Expression<Func<Foo, object>>>();
    
                Foo foo = new Foo();
                Bar bar = new Bar();
                Employee emp = new Employee() { Name = "employee" };
                Bank bank = new Bank() { Name = "bank" };
                Position position = new Position() { Name = "position" };
                foo.Bars = new List<Bar>();
                foo.Bars.Add(bar);
                bar.Employees = new List<Employee>();
                bar.Employees.Add(emp);
                emp.Position = position;
                emp.Bank = bank;
                context.Foos.Add(foo);
                context.SaveChanges();
    
                exp.Add(f => f.Bars.Select(b => b.Employees.Select(e => e.Position)));
                exp.Add(f => f.Bars.Select(b => b.Employees.Select(e => e.Bank)));
    
                DbSet<Foo> dbSet = context.Set<Foo>();
                IQueryable<Foo> query = dbSet;
    
                if (exp != null)
                {
                    foreach (var incProp in exp)
                    {
                        query = query.Include(incProp);
                    }
                }
    
                var first = query.ToList().FirstOrDefault();
                var firstEmp = first.Bars.First().Employees.First();
                Console.WriteLine(String.Format("{0} | {1} | {2}", firstEmp.Name, firstEmp.Bank.Name, firstEmp.Position.Name));
            }
        }
    
    }
