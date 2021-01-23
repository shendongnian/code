    internal sealed class Configuration : DbMigrationsConfiguration<MyProject.Models.MyProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    
    ...
