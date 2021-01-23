    [ Subject( "Inner join example using entity framework") ]
    public class When_getting_towar_by_kategory_and_there_are_2_kategories
    {
        Establish context = () =>
                            {
                                myContext = new MyContext();
                                Database.SetInitializer(new CreateDatabaseIfNotExists<MyContext>());
                                var first = new Kategory { Nazwa = "First" };
                                myContext.Kategories.Add(first);
                                var second = new Kategory { Nazwa = "Second" };
                                myContext.Kategories.Add(second);
                                myContext.Towars.Add(new Towar { Cena = "found", Kategory = first });
                                myContext.Towars.Add(new Towar { Cena = "notFound", Kategory = second });
                                myContext.SaveChanges();
                                SUT = new Controller(myContext);
                            };
    
    
        private Because of = () => { result = SUT.GetTowarByKategory("First"); };
    
        private It should_return_list_filtered_by_kategory = () => { result.Select(x => x.Cena).SequenceEqual(new[] { "found" }).Should().BeTrue(); };
        private static Controller SUT;
        private static IEnumerable<Towar> result;
        private static MyContext myContext;
    }
    
    
    public class Controller
    {
        private readonly MyContext context;
    
        public Controller(MyContext context)
        {
            this.context = context;
        }
        public IEnumerable<Towar> GetTowarByKategory(string category)
        {
            var res = from t in context.Towars
                        where t.Kategory.Nazwa == category
                        select t;
    
            return res;
        }
    }
    
    public class Kategory
    {
        [Key] 
        public int Id_kat { get; set; }
        public string Nazwa { get; set; }
    }
    
    public class Towar
    {
        [Key]
        public int Id_tow { get; set; }
        public Kategory Kategory { get; set; }
        public string Cena { get; set; }
    }
    
    public class MyContext : DbContext
    {
        public DbSet<Kategory> Kategories { get; set; }
        public DbSet<Towar> Towars { get; set; }
    }
