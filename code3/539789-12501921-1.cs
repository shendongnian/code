    public class MyCtx1 : DbContext
    {
        public DbSet<SomeEntity> SomeEntities { get; set; }
        public DbSet<ResourceValue> ResourceValues { get; set; }
    }
    public class SomeEntity
    {
        public int Id { get; set; }
        public virtual ResourceValue Name { get; set; }
    }
    public class ResourceValue
    {
        public int ResourceValueId { get; set; }
        public string EnglishValue { get; set; }
        public string FrenchValue { get; set; }
    }
    class Program
    {
        private static IQueryable<SomeEntity> OrderByName(IQueryable<SomeEntity> source, string culture)
        {
            if (culture == "fr-CA")
            {
                return source.OrderBy(x => x.Name.FrenchValue);
            }
            return source.OrderBy(x => x.Name.EnglishValue);
        }
        static void Main(string[] args)
        {
            using (var context = new MyCtx1())
            {
                if (!context.SomeEntities.Any())
                {
                    context.SomeEntities.Add(
                        new SomeEntity() 
                        { 
                            Name = new ResourceValue()
                            {
                                EnglishValue = "abc - en",
                                FrenchValue = "xyz - fr"
                            }
                        });
                    context.SomeEntities.Add(
                        new SomeEntity() 
                        { 
                            Name = new ResourceValue()
                            {
                                EnglishValue = "xyz - en",
                                FrenchValue = "abc - fr"
                            }
                        });
                    context.SaveChanges();
                }
                Console.WriteLine("Ordered by english name");
                DisplayResults(OrderByName(context.SomeEntities, "en-US"));
                Console.WriteLine("Ordered by french name");
                DisplayResults(OrderByName(context.SomeEntities, "fr-CA"));
            }
        }
        private static void DisplayResults(IQueryable<SomeEntity> q)
        {
            foreach (var e in q)
            {
                Console.WriteLine(e.Id);
            }                
        }
